//PROJECT NAME: CSIAdmin
//CLASS NAME: XOutGDPRDataFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class XOutGDPRDataFactory
    {
        public IXOutGDPRData Create(IApplicationDB appDB)
        {
            var _XOutGDPRData = new XOutGDPRData(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iXOutGDPRDataExt = timerfactory.Create<IXOutGDPRData>(_XOutGDPRData);

            return iXOutGDPRDataExt;
        }
    }
}
