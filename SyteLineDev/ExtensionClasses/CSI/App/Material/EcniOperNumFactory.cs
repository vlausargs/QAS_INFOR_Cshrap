//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniOperNumFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcniOperNumFactory
    {
        public IEcniOperNum Create(IApplicationDB appDB)
        {
            var _EcniOperNum = new EcniOperNum(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcniOperNumExt = timerfactory.Create<IEcniOperNum>(_EcniOperNum);

            return iEcniOperNumExt;
        }
    }
}
