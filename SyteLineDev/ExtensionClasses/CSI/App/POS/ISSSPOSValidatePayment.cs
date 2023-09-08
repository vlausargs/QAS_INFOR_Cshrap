//PROJECT NAME: POS
//CLASS NAME: ISSSPOSValidatePayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSValidatePayment
	{
		(int? ReturnCode,
			string Infobar) SSSPOSValidatePaymentSp(
			string POSMCustNum,
			int? POSMCustSeq,
			string POSMPaymentPayType,
			string POSMOrdType,
			string Infobar);
	}
}

