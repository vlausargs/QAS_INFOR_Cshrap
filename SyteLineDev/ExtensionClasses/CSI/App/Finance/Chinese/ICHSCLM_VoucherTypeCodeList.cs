//PROJECT NAME: Finance
//CLASS NAME: ICHSCLM_VoucherTypeCodeList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_VoucherTypeCodeList
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CHSCLM_VoucherTypeCodeListSp(
			string TypeCodeFilter = null);
	}
}

