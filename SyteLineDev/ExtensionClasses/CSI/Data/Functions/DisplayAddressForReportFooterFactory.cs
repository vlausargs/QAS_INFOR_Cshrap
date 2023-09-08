//PROJECT NAME: Data
//CLASS NAME: DisplayAddressForReportFooterFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class DisplayAddressForReportFooterFactory
    {
        public IDisplayAddressForReportFooter Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _DisplayAddressForReportFooter = new Functions.DisplayAddressForReportFooter(appDB);

            return _DisplayAddressForReportFooter;
        }
    }
}
