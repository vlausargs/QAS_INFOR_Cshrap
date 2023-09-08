//PROJECT NAME: Production
//CLASS NAME: ApsDeriveJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDeriveJob : IApsDeriveJob
	{
		readonly IApplicationDB appDB;
		
		public ApsDeriveJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsDeriveJobSp(
			string OrderTable,
			int? PSuffix,
			string PJobType,
			string PJobJob,
			string PsNum,
			string OrderId,
			string PJobItemJob,
			int? OrdType)
		{
			TableNameType _OrderTable = OrderTable;
			SuffixType _PSuffix = PSuffix;
			JobTypeType _PJobType = PJobType;
			JobType _PJobJob = PJobJob;
			PsNumType _PsNum = PsNum;
			ApsOrderType _OrderId = OrderId;
			JobType _PJobItemJob = PJobItemJob;
			ApsOrdTypeType _OrdType = OrdType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsDeriveJobSp](@OrderTable, @PSuffix, @PJobType, @PJobJob, @PsNum, @OrderId, @PJobItemJob, @OrdType)";
				
				appDB.AddCommandParameter(cmd, "OrderTable", _OrderTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobType", _PJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobJob", _PJobJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PsNum", _PsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderId", _OrderId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobItemJob", _PJobItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrdType", _OrdType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
