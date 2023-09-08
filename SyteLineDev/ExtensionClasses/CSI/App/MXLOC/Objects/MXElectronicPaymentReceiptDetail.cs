using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC.Objects
{
    public class MXElectronicPaymentReceiptDetail : IMXElectronicPaymentReceiptDetail
    {
        public MXElectronicPaymentReceiptDetail(string proFormaInvNum, string paymentDocumentApprovalStamp, string documentIdStamp, string paymentMethod, string currCode, int partialPaymentCount, decimal previousAmount, decimal paidAmount, decimal balanceAmount)
        {
            this.ProFormaInvNum = proFormaInvNum;
            this.PaymentDocumentApprovalStamp = paymentDocumentApprovalStamp;
            this.DocumentIdStamp = documentIdStamp;
            this.PaymentMethod = paymentMethod;
            this.CurrCode = currCode;
            this.PartialPaymentCount = partialPaymentCount;
            this.PreviousAmount = previousAmount;
            this.PaidAmount = paidAmount;
            this.BalanceAmount = balanceAmount;
        }

        public string ProFormaInvNum { get; }
        public string PaymentDocumentApprovalStamp { get; }
        public string DocumentIdStamp { get; }
        public string PaymentMethod { get; }
        public string CurrCode { get; }
        public int PartialPaymentCount { get; }
        public decimal PreviousAmount { get; }
        public decimal PaidAmount { get; }
        public decimal BalanceAmount { get; }
    }
}
