//PROJECT NAME: Production
//CLASS NAME: RSQC_GetIssueValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetIssueValues : IRSQC_GetIssueValues
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetIssueValues(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_acct,
		string o_account_unit1,
		string o_account_unit2,
		string o_account_unit3,
		string o_account_unit4,
		string Infobar) RSQC_GetIssueValuesSp(string o_acct,
		string o_account_unit1,
		string o_account_unit2,
		string o_account_unit3,
		string o_account_unit4,
		string Infobar)
		{
			AcctType _o_acct = o_acct;
			UnitCode1Type _o_account_unit1 = o_account_unit1;
			UnitCode2Type _o_account_unit2 = o_account_unit2;
			UnitCode3Type _o_account_unit3 = o_account_unit3;
			UnitCode4Type _o_account_unit4 = o_account_unit4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetIssueValuesSp";
				
				appDB.AddCommandParameter(cmd, "o_acct", _o_acct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit1", _o_account_unit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit2", _o_account_unit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit3", _o_account_unit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_account_unit4", _o_account_unit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_acct = _o_acct;
				o_account_unit1 = _o_account_unit1;
				o_account_unit2 = _o_account_unit2;
				o_account_unit3 = _o_account_unit3;
				o_account_unit4 = _o_account_unit4;
				Infobar = _Infobar;
				
				return (Severity, o_acct, o_account_unit1, o_account_unit2, o_account_unit3, o_account_unit4, Infobar);
			}
		}
	}
}
