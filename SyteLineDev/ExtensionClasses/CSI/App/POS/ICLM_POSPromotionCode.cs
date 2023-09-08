//PROJECT NAME: POS
//CLASS NAME: ICLM_POSPromotionCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ICLM_POSPromotionCode
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_POSPromotionCodeSp(string Whse = null,
		string Item = null,
		string Slsman = null,
		string EndUserType = null,
		string PromotionCode = null,
		string Infobar = null,
		string CustNum = null,
		int? CustSeq = null);
	}
}

