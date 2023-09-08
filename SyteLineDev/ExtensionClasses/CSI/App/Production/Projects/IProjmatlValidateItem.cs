//PROJECT NAME: Production
//CLASS NAME: IProjmatlValidateItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjmatlValidateItem
	{
		(int? ReturnCode,
		string TItem,
		int? TSeqNum,
		string TItemDesc,
		int? TSerTracked,
		int? TLotTracked,
		string TNonInvAcct,
		decimal? TNonInvCost,
		string TCostCode,
		string TLoc,
		string TLot,
		decimal? TRequired,
		decimal? TIssued,
		decimal? TOnHand,
		string TUM,
		decimal? UomConvFactor,
		decimal? TRequiredConv,
		decimal? TIssuedConv,
		decimal? TOnHandConv,
		decimal? TQty,
		decimal? TQtyConv,
		int? ItemAvailable,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2,
		string Infobar,
		string TImportDocId,
		int? TTaxFreeMatl,
		int? TTrackPieces,
		string TDimensionGroup,
		decimal? TQtyShipped,
		int? IsControl,
		int? ItemTrackECN,
		string Revision) ProjmatlValidateItemSp(
			string Item,
			string ProjNum,
			int? TaskNum,
			int? SeqNum,
			string Whse,
			string TItem,
			int? TSeqNum,
			string TItemDesc,
			int? TSerTracked,
			int? TLotTracked,
			string TNonInvAcct,
			decimal? TNonInvCost,
			string TCostCode,
			string TLoc,
			string TLot,
			decimal? TRequired,
			decimal? TIssued,
			decimal? TOnHand,
			string TUM,
			decimal? UomConvFactor,
			decimal? TRequiredConv,
			decimal? TIssuedConv,
			decimal? TOnHandConv,
			decimal? TQty,
			decimal? TQtyConv,
			int? ItemAvailable,
			string PromptMsg1,
			string PromptButtons1,
			string PromptMsg2,
			string PromptButtons2,
			string Infobar,
			string TImportDocId,
			int? TTaxFreeMatl,
			int? TTrackPieces,
			string TDimensionGroup,
			decimal? TQtyShipped,
			int? IsControl,
			int? ItemTrackECN,
			string Revision);
	}
}

