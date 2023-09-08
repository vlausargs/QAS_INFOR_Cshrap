//PROJECT NAME: Finance
//CLASS NAME: MTDTransactionsResetUtility.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MTDTransactionsResetUtility : IMTDTransactionsResetUtility
	{
		readonly IApplicationDB appDB;
		
		
		public MTDTransactionsResetUtility(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MTDTransactionsResetUtilitySp(string PeriodKey)
		{
			VATPeriodKeyType _PeriodKey = PeriodKey;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MTDTransactionsResetUtilitySp";
				
				appDB.AddCommandParameter(cmd, "PeriodKey", _PeriodKey, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
