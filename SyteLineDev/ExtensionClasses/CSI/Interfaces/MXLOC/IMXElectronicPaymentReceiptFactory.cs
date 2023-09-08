using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC
{
    public interface IMXElectronicPaymentReceiptFactory
    {
        IMXElectronicPaymentReceipt Create(string ProFormaInvNum, string ArPmtCheckNum, string PaymentDocumentApprovalStamp, DateTime PaymentDate, string CurrCode, DateTime SatCertificateDate, string ComplementDigitalStamp, string IssuerDigitalStamp, string SatDigitalStamp, DateTime ReceiptIssueDate, string SatCertificateSerialNumber, string IssuerDigitalStampSerialNumber);
    }
}
