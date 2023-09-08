//PROJECT NAME: Finance
//CLASS NAME: IMXRpt_CFDIPayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXRpt_CFDIPayment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) MXRpt_CFDIPaymentSp(
			int? pPaymentNumStarting = null,
			int? pPaymentNumEnding = null,
			DateTime? pPaymentDateStarting = null,
			DateTime? pPaymentDateEnding = null,
			string pCustomerStarting = null,
			string pCustomerEnding = null,
			string pBankCodeStarting = null,
			string pBankCodeEnding = null,
			int? DisplayHeader = null,
			string pArpmtTypeStarting = null,
			string pArpmtTypeEnding = null);
	}
}

