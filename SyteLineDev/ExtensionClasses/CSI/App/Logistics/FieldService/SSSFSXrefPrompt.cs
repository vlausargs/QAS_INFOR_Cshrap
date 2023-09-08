//PROJECT NAME: Logistics
//CLASS NAME: SSSFSXrefPrompt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSXrefPrompt : ISSSFSXrefPrompt
	{
		readonly IApplicationDB appDB;
		
		
		public SSSFSXrefPrompt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string TXrefDestination,
		int? CreateFlag,
		int? CreateFlag2,
		string PromptMsg,
		string PromptButtons,
		string Infobar) SSSFSXrefPromptSp(string PFromRefType,
		string PFromRefNum,
		int? PFromRefLineSuf,
		int? PFromRefRelease,
		string PToRefType,
		string PToRefNum,
		int? PToRefLineSuf,
		int? PToRefRelease,
		string PCustNum = null,
		int? PCustSeq = null,
		string Item = null,
		string UM = null,
		decimal? Qty = null,
		string Whse = null,
		DateTime? DueDate = null,
		string TXrefDestination = null,
		int? CreateFlag = null,
		int? CreateFlag2 = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null,
		string ToSite = null)
		{
			StringType _PFromRefType = PFromRefType;
			JobPoProjReqTrnNumType _PFromRefNum = PFromRefNum;
			SuffixPoLineProjTaskReqTrnLineType _PFromRefLineSuf = PFromRefLineSuf;
			OperNumPoReleaseType _PFromRefRelease = PFromRefRelease;
			RefTypeIJKPRTType _PToRefType = PToRefType;
			JobPoProjReqTrnNumType _PToRefNum = PToRefNum;
			SuffixPoLineProjTaskReqTrnLineType _PToRefLineSuf = PToRefLineSuf;
			OperNumPoReleaseType _PToRefRelease = PToRefRelease;
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			ItemType _Item = Item;
			UMType _UM = UM;
			QtyUnitType _Qty = Qty;
			WhseType _Whse = Whse;
			DateType _DueDate = DueDate;
			InfobarType _TXrefDestination = TXrefDestination;
			FlagNyType _CreateFlag = CreateFlag;
			FlagNyType _CreateFlag2 = CreateFlag2;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			Infobar _Infobar = Infobar;
			SiteType _ToSite = ToSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSXrefPromptSp";
				
				appDB.AddCommandParameter(cmd, "PFromRefType", _PFromRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromRefNum", _PFromRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromRefLineSuf", _PFromRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromRefRelease", _PFromRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefType", _PToRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefNum", _PToRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefLineSuf", _PToRefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToRefRelease", _PToRefRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TXrefDestination", _TXrefDestination, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag", _CreateFlag, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreateFlag2", _CreateFlag2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TXrefDestination = _TXrefDestination;
				CreateFlag = _CreateFlag;
				CreateFlag2 = _CreateFlag2;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				Infobar = _Infobar;
				
				return (Severity, TXrefDestination, CreateFlag, CreateFlag2, PromptMsg, PromptButtons, Infobar);
			}
		}
	}
}
