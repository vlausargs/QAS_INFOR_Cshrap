//PROJECT NAME: Data
//CLASS NAME: JobmatlCreateXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobmatlCreateXref : IJobmatlCreateXref
	{
		readonly IApplicationDB appDB;
		
		public JobmatlCreateXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAction,
			string Infobar) JobmatlCreateXrefSp(
			string PJob,
			int? PSuffix,
			int? POperNum,
			int? PSeq,
			string PRefType,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			int? PPoChangeOrd,
			string PAction,
			string Infobar,
			string ExportType)
		{
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSeq = PSeq;
			LongListType _PRefType = PRefType;
			LongListType _PRefNum = PRefNum;
			GenericNoType _PRefLineSuf = PRefLineSuf;
			GenericNoType _PRefRelease = PRefRelease;
			FlagNyType _PPoChangeOrd = PPoChangeOrd;
			LongListType _PAction = PAction;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobmatlCreateXrefSp";
				
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoChangeOrd", _PPoChangeOrd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRefNum = _PRefNum;
				PRefLineSuf = _PRefLineSuf;
				PRefRelease = _PRefRelease;
				PAction = _PAction;
				Infobar = _Infobar;
				
				return (Severity, PRefNum, PRefLineSuf, PRefRelease, PAction, Infobar);
			}
		}
	}
}
