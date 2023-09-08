//PROJECT NAME: Finance
//CLASS NAME: AcctRecursiveTest.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class AcctRecursiveTest : IAcctRecursiveTest
	{
		readonly IApplicationDB appDB;
		
		
		public AcctRecursiveTest(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AcctRecursiveTestSp(string PAcct,
        string PDAcct,
        int? NESTLEVEL = 0)
        {
			AcctType _PAcct = PAcct;
			AcctType _PDAcct = PDAcct;
            IntType _NESTLEVEL = NESTLEVEL;

            using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AcctRecursiveTestSp";
				
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDAcct", _PDAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NESTLEVEL", _NESTLEVEL, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
