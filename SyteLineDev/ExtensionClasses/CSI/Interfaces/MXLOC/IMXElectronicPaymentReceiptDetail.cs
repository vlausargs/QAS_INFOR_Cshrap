using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC
{
    public interface IMXElectronicPaymentReceiptDetail
    {
        string ProFormaInvNum { get; }
        string PaymentDocumentApprovalStamp { get; }
        string DocumentIdStamp { get; }
        string PaymentMethod { get; }
        string CurrCode { get; }
        int PartialPaymentCount { get; }
        decimal PreviousAmount { get; }
        decimal PaidAmount { get; }
        decimal BalanceAmount { get; }
        
    }
}
