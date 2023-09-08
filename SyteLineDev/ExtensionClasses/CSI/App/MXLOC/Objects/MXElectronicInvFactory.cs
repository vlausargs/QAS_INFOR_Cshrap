using CSI.MXLOC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC.Objects
{
    public class MXElectronicInvFactory : IMXElectronicInvFactory
    {
        public IMXElectronicInv Create(string ProfFormaInvNum, DateTime SatCertificateDate, string DigitalStampComplement, string DigitalStampIssuer, string DigitalStampSat, DateTime ReceiptIssueDate, string SatCertificateSerialNumber, string DigitalStampSerialNumberIssuer)
        {
            return new MXElectronicInv(ProfFormaInvNum, SatCertificateDate, DigitalStampComplement, DigitalStampIssuer, DigitalStampSat, ReceiptIssueDate, SatCertificateSerialNumber, DigitalStampSerialNumberIssuer);
        }
    }
}
