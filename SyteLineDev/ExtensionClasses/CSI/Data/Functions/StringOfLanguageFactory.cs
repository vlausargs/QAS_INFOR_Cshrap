//PROJECT NAME: Data
//CLASS NAME: StringOfLanguageFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class StringOfLanguageFactory
    {
        public IStringOfLanguage Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _StringOfLanguage = new Functions.StringOfLanguage(appDB);

            return _StringOfLanguage;
        }
    }
}