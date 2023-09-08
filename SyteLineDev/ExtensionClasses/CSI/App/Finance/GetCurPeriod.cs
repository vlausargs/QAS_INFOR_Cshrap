//PROJECT NAME: Finance
//CLASS NAME: GetCurPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GetCurPeriod : IGetCurPeriod
	{
		readonly IApplicationDB appDB;
		
		
		public GetCurPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? pCurPeriod) GetCurPeriodSp(int? pCurPeriod)
		{
			FinPeriodType _pCurPeriod = pCurPeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCurPeriodSp";
				
				appDB.AddCommandParameter(cmd, "pCurPeriod", _pCurPeriod, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pCurPeriod = _pCurPeriod;
				
				return (Severity, pCurPeriod);
			}
		}

		public int? GetCurPeriodFn()
		{

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetCurPeriod]()";

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
