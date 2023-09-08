//PROJECT NAME: Data
//CLASS NAME: FormatAddressForCPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class FormatAddressForCPFactory
    {
        public IFormatAddressForCP Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _FormatAddressForCP = new Functions.FormatAddressForCP(appDB);

            return _FormatAddressForCP;
        }
    }
}