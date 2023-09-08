using System;
using CSI.MXLOC.Interfaces;

namespace CSI.MXLOC.Objects
{
    public interface IMXElectronicInvFactory
    {
        IMXElectronicInv Create(string ProfFormaInvNum, DateTime SatCertificateDate, string DigitalStampComplement, string DigitalStampIssuer, string DigitalStampSat, DateTime ReceiptIssueDate, string SatCertificateSerialNumber, string DigitalStampSerialNumberIssuer);
    }
}