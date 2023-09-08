//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefPrompt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefPrompt
	{
		(int? ReturnCode, string TXrefDestination,
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
		string ToSite = null);
	}
}

