//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteBOM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IDeleteBOM
	{
		int DeleteBOMSp(string PJobType,
		                string PJobmatlJob,
		                short? PJobmatlSuffix,
		                int? PJobmatlOperNum,
		                short? PJobmatlSequence,
		                DateTime? PEffDate,
		                DateTime? PObsDate,
		                Guid? PJobmatlRowPointer);
	}
	
	public class DeleteBOM : IDeleteBOM
	{
		readonly IApplicationDB appDB;
		
		public DeleteBOM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DeleteBOMSp(string PJobType,
		                       string PJobmatlJob,
		                       short? PJobmatlSuffix,
		                       int? PJobmatlOperNum,
		                       short? PJobmatlSequence,
		                       DateTime? PEffDate,
		                       DateTime? PObsDate,
		                       Guid? PJobmatlRowPointer)
		{
			JobTypeType _PJobType = PJobType;
			JobType _PJobmatlJob = PJobmatlJob;
			SuffixType _PJobmatlSuffix = PJobmatlSuffix;
			OperNumType _PJobmatlOperNum = PJobmatlOperNum;
			JobmatlSequenceType _PJobmatlSequence = PJobmatlSequence;
			CurrentDateType _PEffDate = PEffDate;
			CurrentDateType _PObsDate = PObsDate;
			RowPointerType _PJobmatlRowPointer = PJobmatlRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DeleteBOMSp";
				
				appDB.AddCommandParameter(cmd, "PJobType", _PJobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobmatlJob", _PJobmatlJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobmatlSuffix", _PJobmatlSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobmatlOperNum", _PJobmatlOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobmatlSequence", _PJobmatlSequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEffDate", _PEffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PObsDate", _PObsDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobmatlRowPointer", _PJobmatlRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return Severity;
			}
		}
	}
}
