using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC
{
    public interface IMXElectronicPaymentReceiptDetailFactory
    {
        IMXElectronicPaymentReceiptDetail Create(string ProFormaInvNum, string PaymentDocumentApprovalStamp, string DocumentIdStamp, string PaymentMethod, string CurrCode, int PartialPaymentCount, decimal PreviousAmount, decimal PaidAmount, decimal BalanceAmount);
    }
}
