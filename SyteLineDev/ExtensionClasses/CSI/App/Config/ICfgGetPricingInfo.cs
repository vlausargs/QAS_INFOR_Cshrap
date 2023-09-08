//PROJECT NAME: Config
//CLASS NAME: ICfgGetPricingInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Config
{
	public interface ICfgGetPricingInfo
	{
		(int? ReturnCode, int? pDoPricing,
		int? pUseModelPrice,
		decimal? pBasePrice,
		string Infobar) CfgGetPricingInfoSp(string pConfigId,
		int? pDoPricing,
		int? pUseModelPrice,
		decimal? pBasePrice,
		string Infobar);
	}
}

