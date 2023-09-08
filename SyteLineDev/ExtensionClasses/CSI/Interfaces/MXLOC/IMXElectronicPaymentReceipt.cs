using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC
{
    public interface IMXElectronicPaymentReceipt
    {
        string ProFormaInvNum { get; }
        string ArPmtCheckNum { get; }
        string PaymentDocumentApprovalStamp { get; }
        DateTime PaymentDate { get; }
        string CurrCode { get; }
        DateTime SatCertificateDate { get; }
        string ComplementDigitalStamp { get; }
        string IssuerDigitalStamp { get; }
        string SatDigitalStamp { get; }
        DateTime ReceiptIssueDate { get; }
        string SatCertificateSerialNumber { get; }
        string IssuerDigitalStampSerialNumber { get; }
        string ApprovedXmlFilename { get; }
    }
}
