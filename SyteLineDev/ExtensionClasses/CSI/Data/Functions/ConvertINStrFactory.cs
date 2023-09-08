//PROJECT NAME: Data
//CLASS NAME: ConvertINStrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ConvertINStrFactory
    {
        public IConvertINStr Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _ConvertINStr = new Functions.ConvertINStr(appDB);

            return _ConvertINStr;
        }
    }
}
