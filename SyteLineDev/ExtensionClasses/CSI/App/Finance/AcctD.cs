//PROJECT NAME: Finance
//CLASS NAME: AcctD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class AcctD : IAcctD
	{
		readonly IApplicationDB appDB;
		
		
		public AcctD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string rDescription) AcctDSp(string pAccount,
		string rDescription)
		{
			AcctType _pAccount = pAccount;
			DescriptionType _rDescription = rDescription;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AcctDSp";
				
				appDB.AddCommandParameter(cmd, "pAccount", _pAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rDescription", _rDescription, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rDescription = _rDescription;
				
				return (Severity, rDescription);
			}
		}
	}
}
