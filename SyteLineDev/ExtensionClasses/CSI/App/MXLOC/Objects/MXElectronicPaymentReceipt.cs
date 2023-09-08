using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC.Objects
{
    public class MXElectronicPaymentReceipt : IMXElectronicPaymentReceipt
    {
        public MXElectronicPaymentReceipt(string ProFormaInvNum, string ArPmtCheckNum, string PaymentDocumentApprovalStamp, DateTime PaymentDate, string CurrCode, DateTime SatCertificateDate, string ComplementDigitalStamp, string IssuerDigitalStamp, string SatDigitalStamp, DateTime ReceiptIssueDate, string SatCertificateSerialNumber, string IssuerDigitalStampSerialNumber)
        {
            this.ProFormaInvNum = ProFormaInvNum;
            this.ArPmtCheckNum = ArPmtCheckNum;
            this.PaymentDocumentApprovalStamp = PaymentDocumentApprovalStamp;
            this.PaymentDate = PaymentDate;
            this.CurrCode = CurrCode;
            this.SatCertificateDate = SatCertificateDate;
            this.ComplementDigitalStamp = ComplementDigitalStamp;
            this.IssuerDigitalStamp = IssuerDigitalStamp;
            this.SatDigitalStamp = SatDigitalStamp;
            this.ReceiptIssueDate = ReceiptIssueDate;
            this.SatCertificateSerialNumber = SatCertificateSerialNumber;
            this.IssuerDigitalStampSerialNumber = IssuerDigitalStampSerialNumber;
        }

        public string ProFormaInvNum { get; }
        public string ArPmtCheckNum { get; }
        public string PaymentDocumentApprovalStamp { get; }
        public DateTime PaymentDate { get; }
        public string CurrCode { get; }
        public DateTime SatCertificateDate { get; }
        public string ComplementDigitalStamp { get; }
        public string IssuerDigitalStamp { get; }
        public string SatDigitalStamp { get; }
        public DateTime ReceiptIssueDate { get; }
        public string SatCertificateSerialNumber { get; }
        public string IssuerDigitalStampSerialNumber { get; }
        public string ApprovedXmlFilename { get; }
    }
}
