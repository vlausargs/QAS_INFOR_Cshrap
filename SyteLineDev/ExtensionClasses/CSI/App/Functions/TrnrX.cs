//PROJECT NAME: Data
//CLASS NAME: TrnrX.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class TrnrX : ITrnrX
	{
		readonly IApplicationDB appDB;
		
		public TrnrX(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string XrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) TrnrXSp(
			string SourceFile,
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
			InfobarType _SourceFile = SourceFile;
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
				cmd.CommandText = "TrnrXSp";
				
				appDB.AddCommandParameter(cmd, "SourceFile", _SourceFile, ParameterDirection.Input);
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
