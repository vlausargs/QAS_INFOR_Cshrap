//PROJECT NAME: Finance
//CLASS NAME: AllocT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chart
{
	public class AllocT : IAllocT
	{
		readonly IApplicationDB appDB;
		
		public AllocT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string AcctList) AllocTSp(
			string PAcct,
			string AcctList)
		{
			AcctType _PAcct = PAcct;
			LongListType _AcctList = AcctList;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AllocTSp";
				
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctList", _AcctList, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AcctList = _AcctList;
				
				return (Severity, AcctList);
			}
		}
	}
}
