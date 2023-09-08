//PROJECT NAME: Data
//CLASS NAME: IsAddonAvailableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class IsAddonAvailableFactory
    {
        public IIsAddonAvailable Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _IsAddonAvailable = new IsAddonAvailable(appDB);

            return _IsAddonAvailable;
        }

        public IIsAddonAvailable Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _IsAddonAvailable = new Functions.IsAddonAvailable(appDB);


            return _IsAddonAvailable;
        }
    }
}
