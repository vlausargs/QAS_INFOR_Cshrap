//PROJECT NAME: Data
//CLASS NAME: IsMaterialTiedToProject.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsMaterialTiedToProject : IIsMaterialTiedToProject
	{
		readonly IApplicationDB appDB;
		
		public IsMaterialTiedToProject(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsMaterialTiedToProjectFn(
			string pJob,
			int? pSuffix,
			int? pOperNum,
			int? pSequence,
			int? CheckIfSuppliedBySubJob,
			int? CheckJobStatus)
		{
			JobType _pJob = pJob;
			SuffixType _pSuffix = pSuffix;
			OperNumType _pOperNum = pOperNum;
			JobmatlSequenceType _pSequence = pSequence;
			ListYesNoType _CheckIfSuppliedBySubJob = CheckIfSuppliedBySubJob;
			ListYesNoType _CheckJobStatus = CheckJobStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsMaterialTiedToProject](@pJob, @pSuffix, @pOperNum, @pSequence, @CheckIfSuppliedBySubJob, @CheckJobStatus)";
				
				appDB.AddCommandParameter(cmd, "pJob", _pJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSuffix", _pSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pOperNum", _pOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSequence", _pSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckIfSuppliedBySubJob", _CheckIfSuppliedBySubJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckJobStatus", _CheckJobStatus, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
