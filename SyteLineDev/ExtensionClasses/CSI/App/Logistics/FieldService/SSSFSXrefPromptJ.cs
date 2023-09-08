//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefPromptJ.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefPromptJ : ISSSFSXrefPromptJ
	{
		readonly IApplicationDB appDB;
		
		public SSSFSXrefPromptJ(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar) SSSFSXrefPromptJSp(
			string FFile,
			string RefNum,
			int? RefLineSuf,
			string Item,
			string TXrefDestination,
			int? CreateFlag,
			string PromptMsg,
			string PromptButtons,
			string Infobar)
		{
			LongListType _FFile = FFile;
			JobPoProjReqTrnNumType _RefNum = RefNum;
			SuffixPoLineProjTaskReqTrnLineType _RefLineSuf = RefLineSuf;
			ItemType _Item = Item;
			InfobarType _TXrefDestination = TXrefDestination;
			FlagNyType _CreateFlag = CreateFlag;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefPromptJSp";
				
				appDB.AddCommandParameter(cmd, "FFile", _FFile, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TXrefDestination", _TXrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag", _CreateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TXrefDestination = _TXrefDestination;
				CreateFlag = _CreateFlag;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, TXrefDestination, CreateFlag, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
