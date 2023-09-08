//PROJECT NAME: Production
//CLASS NAME: ProjJobXref.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjJobXref : IProjJobXref
	{
		readonly IApplicationDB appDB;
		
		public ProjJobXref(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAction,
			string PToLaunch,
			string Infobar,
			string PromptMsg,
			string PromptButtons) ProjJobXrefSp(
			int? PAsk,
			string PProjNum,
			int? PTaskNum,
			int? PSeq,
			string PRefType,
			string PRefNum,
			int? PRefLineSuf,
			int? PRefRelease,
			string PAction,
			string PToLaunch,
			string Infobar,
			string PromptMsg,
			string PromptButtons,
			string ExportType)
		{
			ListYesNoType _PAsk = PAsk;
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeq = PSeq;
			RefTypeIJPRType _PRefType = PRefType;
			JobPoReqNumType _PRefNum = PRefNum;
			SuffixPoReqLineType _PRefLineSuf = PRefLineSuf;
			OperNumPoReleaseType _PRefRelease = PRefRelease;
			StringType _PAction = PAction;
			InfobarType _PToLaunch = PToLaunch;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjJobXrefSp";
				
				appDB.AddCommandParameter(cmd, "PAsk", _PAsk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefLineSuf", _PRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PRefRelease", _PRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAction", _PAction, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PToLaunch", _PToLaunch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRefNum = _PRefNum;
				PRefLineSuf = _PRefLineSuf;
				PRefRelease = _PRefRelease;
				PAction = _PAction;
				PToLaunch = _PToLaunch;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PRefNum, PRefLineSuf, PRefRelease, PAction, PToLaunch, Infobar, PromptMsg, PromptButtons);
			}
		}
	}
}
