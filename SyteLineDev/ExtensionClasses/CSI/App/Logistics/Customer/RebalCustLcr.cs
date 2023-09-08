//PROJECT NAME: Logistics
//CLASS NAME: RebalCustLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RebalCustLcr : IRebalCustLcr
	{
		readonly IApplicationDB appDB;
		
		
		public RebalCustLcr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? LcrCount) RebalCustLcrSp(string BegCustNum,
		string EndCustNum,
		string BegLcrNum,
		string EndLcrNum,
		int? LcrCount)
		{
			CustNumType _BegCustNum = BegCustNum;
			CustNumType _EndCustNum = EndCustNum;
			LcrNumType _BegLcrNum = BegLcrNum;
			LcrNumType _EndLcrNum = EndLcrNum;
			IntType _LcrCount = LcrCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RebalCustLcrSp";
				
				appDB.AddCommandParameter(cmd, "BegCustNum", _BegCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegLcrNum", _BegLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndLcrNum", _EndLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrCount", _LcrCount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LcrCount = _LcrCount;
				
				return (Severity, LcrCount);
			}
		}
	}
}
