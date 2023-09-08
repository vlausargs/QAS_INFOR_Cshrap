//PROJECT NAME: CSIAPS
//CLASS NAME: ApsJobOrderIdFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsJobOrderIdFactory
    {
        public IApsJobOrderId Create(IApplicationDB appDB)
        {
            var _ApsJobOrderId = new ApsJobOrderId(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsJobOrderIdExt = timerfactory.Create<IApsJobOrderId>(_ApsJobOrderId);

            return iApsJobOrderIdExt;
        }

        public IApsJobOrderId Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _ApsJobOrderId = new ApsJobOrderId(appDB);

            return _ApsJobOrderId;
        }
    }
}