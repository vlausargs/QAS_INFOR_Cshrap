using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC.Objects
{
    public class MXElectronicPaymentReceiptFactory : IMXElectronicPaymentReceiptFactory
    {
        public IMXElectronicPaymentReceipt Create(string ProFormaInvNum, string ArPmtCheckNum, string PaymentDocumentApprovalStamp, DateTime PaymentDate, string CurrCode, DateTime SatCertificateDate, string ComplementDigitalStamp, string IssuerDigitalStamp, string SatDigitalStamp, DateTime ReceiptIssueDate, string SatCertificateSerialNumber, string IssuerDigitalStampSerialNumber)
        {
            return new MXElectronicPaymentReceipt(ProFormaInvNum, ArPmtCheckNum, PaymentDocumentApprovalStamp, PaymentDate, CurrCode, SatCertificateDate, ComplementDigitalStamp, IssuerDigitalStamp, SatDigitalStamp, ReceiptIssueDate, SatCertificateSerialNumber, IssuerDigitalStampSerialNumber);
        }
    }
}
