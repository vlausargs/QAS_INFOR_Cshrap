//PROJECT NAME: CSIMaterial
//CLASS NAME: GuidSystemParCanAnyFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class GuidSystemParCanAnyFactory
    {
        public IGuidSystemParCanAny Create(IApplicationDB appDB)
        {
            var _GuidSystemParCanAny = new GuidSystemParCanAny(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGuidSystemParCanAnyExt = timerfactory.Create<IGuidSystemParCanAny>(_GuidSystemParCanAny);

            return iGuidSystemParCanAnyExt;
        }
    }
}
