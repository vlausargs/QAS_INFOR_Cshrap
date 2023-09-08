//PROJECT NAME: Material
//CLASS NAME: SetLotManufacturer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class SetLotManufacturer : ISetLotManufacturer
	{
		readonly IApplicationDB appDB;
		
		
		public SetLotManufacturer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SetLotManufacturerSp(string Item = null,
		string Lot = null,
		string Manufacturer = null,
		string ManufacturerItem = null,
		int? SetAllowFlag = 1)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			ManufacturerIdType _Manufacturer = Manufacturer;
			ManufacturerItemType _ManufacturerItem = ManufacturerItem;
			ListYesNoType _SetAllowFlag = SetAllowFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetLotManufacturerSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Manufacturer", _Manufacturer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ManufacturerItem", _ManufacturerItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetAllowFlag", _SetAllowFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
