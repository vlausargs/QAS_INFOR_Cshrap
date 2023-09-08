using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC.Objects
{
    public class MXElectronicPaymentReceiptDetailFactory : IMXElectronicPaymentReceiptDetailFactory
    {
        public IMXElectronicPaymentReceiptDetail Create(string ProFormaInvNum, string PaymentDocumentApprovalStamp, string DocumentIdStamp, string PaymentMethod, string CurrCode, int PartialPaymentCount, decimal PreviousAmount, decimal PaidAmount, decimal BalanceAmount)
        {
            return new MXElectronicPaymentReceiptDetail(ProFormaInvNum, PaymentDocumentApprovalStamp, DocumentIdStamp, PaymentMethod, CurrCode, PartialPaymentCount, PreviousAmount, PaidAmount, BalanceAmount);
        }
    }
}
