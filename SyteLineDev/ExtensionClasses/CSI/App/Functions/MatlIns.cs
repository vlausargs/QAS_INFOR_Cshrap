//PROJECT NAME: Data
//CLASS NAME: MatlIns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MatlIns : IMatlIns
	{
		readonly IApplicationDB appDB;
		
		public MatlIns(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string CurJob,
			int? CurSuffix,
			int? CurSequence,
			string Infobar) MatlInsSp(
			int? CurOper,
			string CurJob,
			int? CurSuffix,
			int? CurSequence,
			string Infobar)
		{
			OperNumType _CurOper = CurOper;
			JobType _CurJob = CurJob;
			SuffixType _CurSuffix = CurSuffix;
			JobmatlSequenceType _CurSequence = CurSequence;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MatlInsSp";
				
				appDB.AddCommandParameter(cmd, "CurOper", _CurOper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurJob", _CurJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurSuffix", _CurSuffix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurSequence", _CurSequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CurJob = _CurJob;
				CurSuffix = _CurSuffix;
				CurSequence = _CurSequence;
				Infobar = _Infobar;
				
				return (Severity, CurJob, CurSuffix, CurSequence, Infobar);
			}
		}
	}
}
