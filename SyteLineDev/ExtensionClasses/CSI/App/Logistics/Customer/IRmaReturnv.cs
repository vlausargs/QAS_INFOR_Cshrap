//PROJECT NAME: Logistics
//CLASS NAME: IRmaReturnv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaReturnv
	{
		(int? ReturnCode, int? ParamSuccessFlag,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
		int? CallForm) RmaReturnvSp(int? ParamPostFlag,
		string ParamRmaNum,
		int? ParamRmaLine,
		decimal? ParamQtyToReturnConv,
		decimal? ParamQtyToReturn,
		string ParamLoc,
		string ParamLot,
		int? ParamSerialConfirmed,
		int? ParamRtnToStk,
		string ParamReasonCode,
		string ParamWorkkey,
		DateTime? ParamTransDate,
		string ParamTMText,
		int? ParamSuccessFlag,
		string Infobar,
		string ParamImportDocId,
		decimal? ParamMatlCost = null,
		decimal? ParamLbrCost = null,
		decimal? ParamFovCost = null,
		decimal? ParamVovCost = null,
		decimal? ParamOutCost = null,
		string Container = null,
		string PromptMsg = null,
		string PromptButtons = null,
		int? CallForm = 0,
		string ParamDocumentNum = null);
	}
}

