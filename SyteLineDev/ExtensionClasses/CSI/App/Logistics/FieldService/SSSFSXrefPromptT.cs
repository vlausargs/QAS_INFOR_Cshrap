//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefPromptT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefPromptT : ISSSFSXrefPromptT
	{
		readonly IApplicationDB appDB;
		
		public SSSFSXrefPromptT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string XrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptTSp(
			string FFile,
			string RefNum,
			int? RefLineSuf,
			int? RefRelease,
			string Item,
			string XrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			LongListType _FFile = FFile;
			JobPoReqNumType _RefNum = RefNum;
			SuffixPoReqLineType _RefLineSuf = RefLineSuf;
			CoReleaseType _RefRelease = RefRelease;
			ItemType _Item = Item;
			InfobarType _XrefDestination = XrefDestination;
			ListYesNoType _CreateFlag = CreateFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefPromptTSp";
				
				appDB.AddCommandParameter(cmd, "FFile", _FFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XrefDestination", _XrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag", _CreateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				XrefDestination = _XrefDestination;
				CreateFlag = _CreateFlag;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, XrefDestination, CreateFlag, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
