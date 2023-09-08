//PROJECT NAME: Material
//CLASS NAME: IVendorConsignQtyAvailforItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IVendorConsignQtyAvailforItem
	{
		(int? ReturnCode, decimal? ConsignQtyRequired,
		string ConsignVdrWhse,
		string ConsignVdrLoc,
		string PromptMsg,
		string PromptButtons,
		string Infobar) VendorConsignQtyAvailforItemSp(string CheckType,
		string CurrentWhse,
		string Item = null,
		string Job = null,
		string Loc = null,
		string Lot = null,
		int? JobSuffix = null,
		int? JobmatlOperNum = null,
		int? JobmatlSequence = null,
		string ProjNum = null,
		int? TaskNum = null,
		int? ProjmatSeq = null,
		decimal? QtyRequired = null,
		decimal? ConsignQtyRequired = null,
		string ConsignVdrWhse = null,
		string ConsignVdrLoc = null,
		string PromptMsg = null,
		string PromptButtons = null,
		string Infobar = null);
	}
}

