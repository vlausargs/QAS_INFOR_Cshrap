//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCreatePayd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCreatePayd
	{
		(int? ReturnCode,
			string Infobar) SSSPOSCreatePaydSp(
			string PType,
			string CoNum,
			string InvNum,
			decimal? Amount,
			string ArpmtBankCode,
			string ArpmtCustNum,
			string ArpmtPmtType,
			int? ArpmtCheckNum,
			DateTime? ArpmtRecptDate,
			decimal? ArpmtExchRate,
			string CustAddrCurrCode,
			string CustAddrBalMethod,
			string ParmCurrCode,
			string ParmSite,
			string Infobar,
			int? POSMCredit,
			string POSMNum,
			string ArpmtPaymentCurrCode,
			decimal? ArpmtPaymentExchRate);
	}
}

