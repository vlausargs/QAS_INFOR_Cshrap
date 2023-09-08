//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefPromptS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefPromptS : ISSSFSXrefPromptS
	{
		readonly IApplicationDB appDB;
		
		public SSSFSXrefPromptS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PXrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptSSp(
			string PToFile,
			string PToRefNum,
			int? PToRefLineSuf,
			int? PToRefRelease,
			string PFromFile,
			string PFromRefType,
			string PFromRefNum,
			int? PFromRefLineSuf,
			int? PFromRefRelease,
			string PCustNum,
			int? PCustSeq,
			string PXrefDestination,
			int? CreateFlag,
			int? CreateLineFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			LongListType _PToFile = PToFile;
			JobPoReqNumType _PToRefNum = PToRefNum;
			SuffixPoReqLineType _PToRefLineSuf = PToRefLineSuf;
			PoReleaseType _PToRefRelease = PToRefRelease;
			LongListType _PFromFile = PFromFile;
			FSRefTypeIJKMNOPRType _PFromRefType = PFromRefType;
			JobPoReqNumType _PFromRefNum = PFromRefNum;
			SuffixPoReqLineType _PFromRefLineSuf = PFromRefLineSuf;
			PoReleaseType _PFromRefRelease = PFromRefRelease;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			InfobarType _PXrefDestination = PXrefDestination;
			ListYesNoType _CreateFlag = CreateFlag;
			ListYesNoType _CreateLineFlag = CreateLineFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefPromptSSp";
				
				appDB.AddCommandParameter(cmd, "PToFile", _PToFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefNum", _PToRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefLineSuf", _PToRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefRelease", _PToRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromFile", _PFromFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromRefType", _PFromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromRefNum", _PFromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromRefLineSuf", _PFromRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromRefRelease", _PFromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PXrefDestination", _PXrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag", _CreateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateLineFlag", _CreateLineFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PXrefDestination = _PXrefDestination;
				CreateFlag = _CreateFlag;
				CreateLineFlag = _CreateLineFlag;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, PXrefDestination, CreateFlag, CreateLineFlag, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
