//PROJECT NAME: Production
//CLASS NAME: ApsBomOrderQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBomOrderQty : IApsBomOrderQty
	{
		readonly IApplicationDB appDB;
		
		public ApsBomOrderQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ApsBomOrderQtyFn(
			string pJob,
			int? pSuffix,
			int? pOperNum,
			decimal? pSequence)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			OperNumType _pOperNum = pOperNum;
			SequenceType _pSequence = pSequence;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsBomOrderQty](@pJob, @pSuffix, @pOperNum, @pSequence)";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOperNum", _pOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSequence", _pSequence, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
