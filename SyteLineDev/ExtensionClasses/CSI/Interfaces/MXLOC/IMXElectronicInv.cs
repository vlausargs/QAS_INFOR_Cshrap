using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC.Interfaces
{
    public interface IMXElectronicInv
    {
        string ProFormaInvNum { get; }
        DateTime SatCertificateDate { get; }
        string DigitalStampComplement { get; }
        string DigitalStampIssuer { get; }
        string DigitalStampSat { get; }
        DateTime ReceiptIssueDate { get; }
        string SatCertificateSerialNumber { get; }
        string DigitalStampSerialNumberIssuer { get; }
        string ApprovedXmlFilename { get; }
    }
}
