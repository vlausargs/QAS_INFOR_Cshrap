//PROJECT NAME: Logistics
//CLASS NAME: AU_CheckPoLineAndBlanket.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AU_CheckPoLineAndBlanket : IAU_CheckPoLineAndBlanket
	{
		readonly IApplicationDB appDB;
		
		
		public AU_CheckPoLineAndBlanket(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string UM,
		string Description,
		string VendorItem,
		string VendorUM,
		string Infobar) AU_CheckPoLineAndBlanketSp(string PoNum,
		int? PoLine,
		string Item,
		string UM,
		string Description,
		string VendorItem,
		string VendorUM,
		string Infobar)
		{
			PoNumType _PoNum = PoNum;
			PoLineType _PoLine = PoLine;
			ItemType _Item = Item;
			UMType _UM = UM;
			DescriptionType _Description = Description;
			VendItemType _VendorItem = VendorItem;
			UMType _VendorUM = VendorUM;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_CheckPoLineAndBlanketSp";
				
				appDB.AddCommandParameter(cmd, "PoNum", _PoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoLine", _PoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendorItem", _VendorItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendorUM", _VendorUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				UM = _UM;
				Description = _Description;
				VendorItem = _VendorItem;
				VendorUM = _VendorUM;
				Infobar = _Infobar;
				
				return (Severity, Item, UM, Description, VendorItem, VendorUM, Infobar);
			}
		}
	}
}
