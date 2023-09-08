//PROJECT NAME: Production
//CLASS NAME: JobmatlXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class JobmatlXref : IJobmatlXref
	{
		readonly IApplicationDB appDB;
		
		
		public JobmatlXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PAsk,
		string PRefNum,
		int? PRefLine,
		int? PRefRelease,
		decimal? POrderQty,
		string PPoType,
		string PCommand,
		string PromptMsg,
		string Buttons,
		string Infobar) JobmatlXrefSp(int? PAsk,
		string PRefType,
		string PJob,
		int? PSuffix,
		int? POperNum,
		int? PSeq,
		string PItem,
		string PRefNum,
		int? PRefLine,
		int? PRefRelease,
		decimal? POrderQty,
		string PPoType,
		string PCommand,
		string PromptMsg,
		string Buttons,
		string Infobar,
		string ExportType)
		{
			FlagNyType _PAsk = PAsk;
			RefTypeIJPRType _PRefType = PRefType;
			JobType _PJob = PJob;
			SuffixType _PSuffix = PSuffix;
			OperNumType _POperNum = POperNum;
			JobmatlSequenceType _PSeq = PSeq;
			ItemType _PItem = PItem;
			JobPoReqNumType _PRefNum = PRefNum;
			SuffixPoReqTrnLineType _PRefLine = PRefLine;
			OperNumPoReleaseType _PRefRelease = PRefRelease;
			QtyUnitType _POrderQty = POrderQty;
			PoTypeType _PPoType = PPoType;
			DescriptionType _PCommand = PCommand;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Buttons = Buttons;
			InfobarType _Infobar = Infobar;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JobmatlXrefSp";
				
				appDB.AddCommandParameter(cmd, "PAsk", _PAsk, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJob", _PJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POperNum", _POperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefLine", _PRefLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POrderQty", _POrderQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPoType", _PPoType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCommand", _PCommand, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Buttons", _Buttons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAsk = _PAsk;
				PRefNum = _PRefNum;
				PRefLine = _PRefLine;
				PRefRelease = _PRefRelease;
				POrderQty = _POrderQty;
				PPoType = _PPoType;
				PCommand = _PCommand;
				PromptMsg = _PromptMsg;
				Buttons = _Buttons;
				Infobar = _Infobar;
				
				return (Severity, PAsk, PRefNum, PRefLine, PRefRelease, POrderQty, PPoType, PCommand, PromptMsg, Buttons, Infobar);
			}
		}
	}
}
