//PROJECT NAME: Reporting
//CLASS NAME: IRpt_UmCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_UmCheck
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_UmCheckSp(string Selection,
		string OldUM,
		string NewUM,
		string Item,
		string ConvType,
		string CustVendType,
		decimal? ConvFactor,
		decimal? ConvDivisor,
		int? RptFlag,
		string pSite = null);
	}
}

