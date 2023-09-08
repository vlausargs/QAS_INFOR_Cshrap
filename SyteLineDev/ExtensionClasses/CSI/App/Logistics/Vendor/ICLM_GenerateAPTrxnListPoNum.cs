//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GenerateAPTrxnListPoNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_GenerateAPTrxnListPoNum
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GenerateAPTrxnListPoNumSp(string PVendNum,
		string PGenerateVoucher = "V",
		string CurrCode = null);
	}
}

