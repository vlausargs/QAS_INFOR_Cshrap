//PROJECT NAME: Data
//CLASS NAME: ApsForecastOrderIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Data.Functions
{
    public class ApsForecastOrderIdFactory
    {
        public IApsForecastOrderId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ApsForecastOrderId = new Functions.ApsForecastOrderId(appDB);

            return _ApsForecastOrderId;
        }
    }
}
