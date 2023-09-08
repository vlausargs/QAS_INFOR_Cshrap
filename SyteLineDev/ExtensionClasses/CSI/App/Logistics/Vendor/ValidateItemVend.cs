//PROJECT NAME: CSIVendor
//CLASS NAME: ValidateItemVend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IValidateItemVend
	{
		int ValidateItemVendSp(string VendNum,
		                       string VendItem,
		                       string Item,
		                       ref string Infobar);
	}
	
	public class ValidateItemVend : IValidateItemVend
	{
		readonly IApplicationDB appDB;
		
		public ValidateItemVend(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateItemVendSp(string VendNum,
		                              string VendItem,
		                              string Item,
		                              ref string Infobar)
		{
			VendNumType _VendNum = VendNum;
			VendItemType _VendItem = VendItem;
			ItemType _Item = Item;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateItemVendSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendItem", _VendItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
