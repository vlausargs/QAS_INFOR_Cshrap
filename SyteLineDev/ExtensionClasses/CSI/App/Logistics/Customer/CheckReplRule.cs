//PROJECT NAME: CSICustomer
//CLASS NAME: CheckReplRule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICheckReplRule
	{
		int CheckReplRuleSp(ref string Infobar);
	}
	
	public class CheckReplRule : ICheckReplRule
	{
		readonly IApplicationDB appDB;
		
		public CheckReplRule(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CheckReplRuleSp(ref string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckReplRuleSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
