//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpTransferOrderInfoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsCtpTransferOrderInfoFactory
    {
        public IApsCtpTransferOrderInfo Create(IApplicationDB appDB)
        {
            var _ApsCtpTransferOrderInfo = new ApsCtpTransferOrderInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsCtpTransferOrderInfoExt = timerfactory.Create<IApsCtpTransferOrderInfo>(_ApsCtpTransferOrderInfo);

            return iApsCtpTransferOrderInfoExt;
        }
    }
}
