//PROJECT NAME: Logistics
//CLASS NAME: ITransAdd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ITransAdd
	{
		(int? ReturnCode, string CurTrnNum,
		int? CurTrnLine,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar) TransAddSp(string PTrnNum,
		string PItem,
		string PFromSite,
		string PFromWhse,
		string PToSite,
		string PToWhse,
		decimal? PQtyOrdered,
		DateTime? PDueDate,
		string PToRefType,
		string PToRefNum,
		int? PToRefLineSuf,
		int? PToRefRelease,
		int? PFromMrpFirm,
		string PRcptsRefNum,
		string CurTrnNum,
		int? CurTrnLine,
		string TrnLoc,
		string FOBSite,
		int? ItemLocQuestionAsked,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		int? CreateTransitLoc = 0);
	}
}

