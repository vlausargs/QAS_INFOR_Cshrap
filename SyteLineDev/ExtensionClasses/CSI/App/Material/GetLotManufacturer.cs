//PROJECT NAME: CSIMaterial
//CLASS NAME: GetLotManufacturer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetLotManufacturer
	{
		(int? ReturnCode, string LotManufacturer, string LotManufacturerName, string LotManufacturerItem, string LotManItemDescription) GetLotManufacturerSp(string Item = null,
		string Lot = null,
		string LotManufacturer = null,
		string LotManufacturerName = null,
		string LotManufacturerItem = null,
		string LotManItemDescription = null);
	}
	
	public class GetLotManufacturer : IGetLotManufacturer
	{
		readonly IApplicationDB appDB;
		
		public GetLotManufacturer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string LotManufacturer, string LotManufacturerName, string LotManufacturerItem, string LotManItemDescription) GetLotManufacturerSp(string Item = null,
		string Lot = null,
		string LotManufacturer = null,
		string LotManufacturerName = null,
		string LotManufacturerItem = null,
		string LotManItemDescription = null)
		{
			ItemType _Item = Item;
			LotType _Lot = Lot;
			ManufacturerIdType _LotManufacturer = LotManufacturer;
			NameType _LotManufacturerName = LotManufacturerName;
			ManufacturerItemType _LotManufacturerItem = LotManufacturerItem;
			DescriptionType _LotManItemDescription = LotManItemDescription;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetLotManufacturerSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotManufacturer", _LotManufacturer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotManufacturerName", _LotManufacturerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotManufacturerItem", _LotManufacturerItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotManItemDescription", _LotManItemDescription, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LotManufacturer = _LotManufacturer;
				LotManufacturerName = _LotManufacturerName;
				LotManufacturerItem = _LotManufacturerItem;
				LotManItemDescription = _LotManItemDescription;
				
				return (Severity, LotManufacturer, LotManufacturerName, LotManufacturerItem, LotManItemDescription);
			}
		}
	}
}
