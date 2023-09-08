//PROJECT NAME: Production
//CLASS NAME: ProjPmatlX.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjPmatlX : IProjPmatlX
	{
		readonly IApplicationDB appDB;
		
		
		public ProjPmatlX(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string PAction,
		string PToLaunch,
		int? PoChangeOrd,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string PromptMsg4,
		string PromptButtons4,
		string PromptMsg5,
		string PromptButtons5,
		string PFromSite,
		string PFromWhse,
		string PCurRefNum,
		string PCurRefLineSuf) ProjPmatlXSp(int? PAsk,
		string PProjNum,
		int? PTaskNum,
		int? PSeq,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		int? PRefRelease,
		string PAction,
		string PToLaunch,
		int? PoChangeOrd,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string PromptMsg3,
		string PromptButtons3,
		string PromptMsg4,
		string PromptButtons4,
		string PromptMsg5,
		string PromptButtons5,
		string ExportType,
		string PFromSite,
		string PFromWhse,
		string PToSite,
		string PToWhse,
		decimal? PQtyOrdered,
		DateTime? PDueDate,
		string PCurRefNum,
		string PCurRefLineSuf,
		string TrnLoc,
		string FOBSite)
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
			ListYesNoType _PoChangeOrd = PoChangeOrd;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _PromptMsg1 = PromptMsg1;
			InfobarType _PromptButtons1 = PromptButtons1;
			InfobarType _PromptMsg2 = PromptMsg2;
			InfobarType _PromptButtons2 = PromptButtons2;
			InfobarType _PromptMsg3 = PromptMsg3;
			InfobarType _PromptButtons3 = PromptButtons3;
			InfobarType _PromptMsg4 = PromptMsg4;
			InfobarType _PromptButtons4 = PromptButtons4;
			InfobarType _PromptMsg5 = PromptMsg5;
			InfobarType _PromptButtons5 = PromptButtons5;
			ListDirectIndirectNonExportType _ExportType = ExportType;
			SiteType _PFromSite = PFromSite;
			WhseType _PFromWhse = PFromWhse;
			SiteType _PToSite = PToSite;
			WhseType _PToWhse = PToWhse;
			QtyUnitType _PQtyOrdered = PQtyOrdered;
			DateType _PDueDate = PDueDate;
			JobPoReqNumType _PCurRefNum = PCurRefNum;
			JobPoReqNumType _PCurRefLineSuf = PCurRefLineSuf;
			LocType _TrnLoc = TrnLoc;
			SiteType _FOBSite = FOBSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjPmatlXSp";
				
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
				appDB.AddCommandParameter(cmd, "PoChangeOrd", _PoChangeOrd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg1", _PromptMsg1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons1", _PromptButtons1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg2", _PromptMsg2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons2", _PromptButtons2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg3", _PromptMsg3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons3", _PromptButtons3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg4", _PromptMsg4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons4", _PromptButtons4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg5", _PromptMsg5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons5", _PromptButtons5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExportType", _ExportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFromWhse", _PFromWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PToSite", _PToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToWhse", _PToWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PQtyOrdered", _PQtyOrdered, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurRefNum", _PCurRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCurRefLineSuf", _PCurRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FOBSite", _FOBSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PRefNum = _PRefNum;
				PRefLineSuf = _PRefLineSuf;
				PRefRelease = _PRefRelease;
				PAction = _PAction;
				PToLaunch = _PToLaunch;
				PoChangeOrd = _PoChangeOrd;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				PromptMsg1 = _PromptMsg1;
				PromptButtons1 = _PromptButtons1;
				PromptMsg2 = _PromptMsg2;
				PromptButtons2 = _PromptButtons2;
				PromptMsg3 = _PromptMsg3;
				PromptButtons3 = _PromptButtons3;
				PromptMsg4 = _PromptMsg4;
				PromptButtons4 = _PromptButtons4;
				PromptMsg5 = _PromptMsg5;
				PromptButtons5 = _PromptButtons5;
				PFromSite = _PFromSite;
				PFromWhse = _PFromWhse;
				PCurRefNum = _PCurRefNum;
				PCurRefLineSuf = _PCurRefLineSuf;
				
				return (Severity, PRefNum, PRefLineSuf, PRefRelease, PAction, PToLaunch, PoChangeOrd, Infobar, PromptMsg, PromptButtons, PromptMsg1, PromptButtons1, PromptMsg2, PromptButtons2, PromptMsg3, PromptButtons3, PromptMsg4, PromptButtons4, PromptMsg5, PromptButtons5, PFromSite, PFromWhse, PCurRefNum, PCurRefLineSuf);
			}
		}
	}
}
