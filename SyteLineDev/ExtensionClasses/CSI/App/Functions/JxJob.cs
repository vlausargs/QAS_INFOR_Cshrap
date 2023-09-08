//PROJECT NAME: Data
//CLASS NAME: JxJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JxJob : IJxJob
	{
		readonly IApplicationDB appDB;
		
		public JxJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PAction,
			string Infobar) JxJobSp(
			string NextJob,
			int? NextSuffix,
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PAction,
			string Infobar,
			string ExportType)
		{
			LongListType _NextJob = NextJob;
			GenericNoType _NextSuffix = NextSuffix;
			LongListType _PJob = PJob;
			GenericNoType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSeq = PSeq;
			LongListType _PAction = PAction;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JxJobSp";
				
				appDB.AddCommandParameter(cmd, "NextJob", _NextJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextSuffix", _NextSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAction = _PAction;
				Infobar = _Infobar;
				
				return (Severity, PAction, Infobar);
			}
		}
	}
}
