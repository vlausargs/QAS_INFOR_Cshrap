using CSI.MXLOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC.Objects
{
    public class MXElectronicInv : IMXElectronicInv
    {
        public MXElectronicInv(string ProFormaInvNum, DateTime SatCertificateDate, string DigitalStampComplement, string DigitalStampIssuer, string DigitalStampSat, DateTime ReceiptIssueDate, string SatCertificateSerialNumber, string DigitalStampSerialNumberIssuer)
        {
            this.ProFormaInvNum = ProFormaInvNum;
            this.SatCertificateDate = SatCertificateDate;
            this.DigitalStampComplement = DigitalStampComplement;
            this.DigitalStampIssuer = DigitalStampIssuer;
            this.DigitalStampSat = DigitalStampSat;
            this.ReceiptIssueDate = ReceiptIssueDate;
            this.SatCertificateSerialNumber = SatCertificateSerialNumber;
            this.DigitalStampSerialNumberIssuer = DigitalStampSerialNumberIssuer;
        }

        public string ProFormaInvNum { get; }
        public DateTime SatCertificateDate { get; }
        public string DigitalStampComplement { get; }
        public string DigitalStampIssuer { get; }
        public string DigitalStampSat { get; }
        public DateTime ReceiptIssueDate { get; }
        public string SatCertificateSerialNumber { get; }
        public string DigitalStampSerialNumberIssuer { get; }
        public string ApprovedXmlFilename { get; }
    }
}
