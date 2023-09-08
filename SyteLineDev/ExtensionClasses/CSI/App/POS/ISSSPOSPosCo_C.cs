//PROJECT NAME: POS
//CLASS NAME: ISSSPOSPosCo_C.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSPosCo_C
	{
		(int? ReturnCode,
			string TInvNum,
			string Infobar) SSSPOSPosCo_CSp(
			string POSNum,
			string InvCred,
			string ParmCurrCode,
			string ParmSite,
			decimal? UserID,
			Guid? SessionID,
			string CurUserCode,
			decimal? POSMTotalBilled,
			decimal? POSMTotalPrepaidAmt,
			string POSMRefNum,
			string POSMRevPOSNum,
			int? POSMCredit,
			string POSMCustNum,
			int? POSMCustSeq,
			decimal? POSMDisc,
			string POSMCustPo,
			Guid? POSMRowPointer,
			string POSMTaxCode1,
			string POSMTaxCode2,
			string POSMShipCode,
			decimal? POSMSalesTax,
			decimal? POSMSalesTax2,
			string POSMFrtTaxCode1,
			string POSMFrtTaxCode2,
			string POSMMscTaxCode1,
			string POSMMscTaxCode2,
			decimal? POSMFreight,
			decimal? POSMMiscCharges,
			string POSMContact,
			string POSMPhone,
			string POSMWhse,
			string POSMCredInvNum,
			Guid? CustomerRowPointer,
			string CustomerBankCode,
			int? CustAddrCorpCredit,
			string CustAddrCurrCode,
			string CustAddrBalMethod,
			string POSMTermsCode,
			string POSMSlsman,
			string POSMEndUserType,
			string TInvNum,
			string Infobar);
	}
}

