//PROJECT NAME: Logistics
//CLASS NAME: IValidateAndSetVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateAndSetVendor
	{
		(int? ReturnCode, string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons,
		string VendPriceBy,
		decimal? TcCprMatCostConv,
		decimal? TcCprBrokerageCostConv,
		decimal? TcCprDutyCostConv,
		decimal? TcCprFreightCostConv,
		decimal? TcCprInsuranceCostConv,
		decimal? TcCprLocFrtCostConv,
		string Infobar) ValidateAndSetVendorSp(string PVendNum,
		string POldVendNum,
		string PItem,
		string PReqNum,
		string PUM,
		DateTime? PDueDate,
		string PRefType,
		decimal? InPoQty,
		DateTime? EffectiveDate,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		decimal? PPlanCostConv,
		string PVendCurrCode,
		string PNewUM,
		DateTime? PNewDte,
		string PromptMsg,
		string PromptButtons,
		string VendPriceBy,
		decimal? TcCprMatCostConv,
		decimal? TcCprBrokerageCostConv,
		decimal? TcCprDutyCostConv,
		decimal? TcCprFreightCostConv,
		decimal? TcCprInsuranceCostConv,
		decimal? TcCprLocFrtCostConv,
		string Infobar);
	}
}

