//PROJECT NAME: Logistics
//CLASS NAME: ValidateNewItemVend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateNewItemVend : IValidateNewItemVend
	{
		readonly IApplicationDB appDB;
		
		
		public ValidateNewItemVend(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string Infobar) ValidateNewItemVendSp(string VendNum,
		string Item,
		string Infobar)
		{
			VendNumType _VendNum = VendNum;
			ItemType _Item = Item;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateNewItemVendSp";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Infobar = _Infobar;
				
				return (Severity, Item, Infobar);
			}
		}
	}
}
