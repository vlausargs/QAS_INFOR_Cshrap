//PROJECT NAME: Logistics
//CLASS NAME: IUomConvAmtQtyInvAdjs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUomConvAmtQtyInvAdjs
	{
		(int? ReturnCode, decimal? ConvertedAmt,
		decimal? ConvertedQty,
		string Infobar,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons) UomConvAmtQtyInvAdjsSp(decimal? AmtToBeConverted,
		decimal? UomConvFactor,
		string FROMBase,
		decimal? ConvertedAmt,
		decimal? QtyToBeConverted,
		decimal? ConvertedQty,
		string Infobar,
		string PMode,
		string PRecidCo,
		decimal? PMiscCharges,
		decimal? PFreight,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		decimal? PLineNet,
		decimal? PPrice,
		int? PSeq,
		string PromptMsg,
		string PromptButtons);
	}
}

