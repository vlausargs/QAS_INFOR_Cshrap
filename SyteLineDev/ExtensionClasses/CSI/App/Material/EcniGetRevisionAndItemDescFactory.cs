//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniGetRevisionAndItemDescFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniGetRevisionAndItemDescFactory
    {
        public IEcniGetRevisionAndItemDesc Create(IApplicationDB appDB)
        {
            var _EcniGetRevisionAndItemDesc = new EcniGetRevisionAndItemDesc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniGetRevisionAndItemDescExt = timerfactory.Create<IEcniGetRevisionAndItemDesc>(_EcniGetRevisionAndItemDesc);

            return iEcniGetRevisionAndItemDescExt;
        }
    }
}
