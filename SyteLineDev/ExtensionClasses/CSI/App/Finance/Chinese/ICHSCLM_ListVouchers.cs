//PROJECT NAME: Finance
//CLASS NAME: ICHSCLM_ListVouchers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_ListVouchers
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CHSCLM_ListVouchersSp(
			string FilterString = null);
	}
}

