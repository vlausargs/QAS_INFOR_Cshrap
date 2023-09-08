//PROJECT NAME: CSICustomer
//CLASS NAME: ValidateDelInvCat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IValidateDelInvCat
	{
		int ValidateDelInvCatSp(string InvCategory,
		                        ref string Infobar);
	}
	
	public class ValidateDelInvCat : IValidateDelInvCat
	{
		readonly IApplicationDB appDB;
		
		public ValidateDelInvCat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ValidateDelInvCatSp(string InvCategory,
		                               ref string Infobar)
		{
			InvCategoryType _InvCategory = InvCategory;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ValidateDelInvCatSp";
				
				appDB.AddCommandParameter(cmd, "InvCategory", _InvCategory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
