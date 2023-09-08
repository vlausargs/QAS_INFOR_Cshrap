//PROJECT NAME: Data
//CLASS NAME: GetCatalogRowPointerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class GetCatalogRowPointerFactory
    {
        public IGetCatalogRowPointer Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _GetCatalogRowPointer = new Functions.GetCatalogRowPointer(appDB);


            return _GetCatalogRowPointer;
        }
    }
}
