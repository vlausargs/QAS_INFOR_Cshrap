//PROJECT NAME: CSIMaterial
//CLASS NAME: VerifyUniqueLotFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class VerifyUniqueLotFactory
    {
        public IVerifyUniqueLot Create(IApplicationDB appDB)
        {
            var _VerifyUniqueLot = new VerifyUniqueLot(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iVerifyUniqueLotExt = timerfactory.Create<IVerifyUniqueLot>(_VerifyUniqueLot);

            return iVerifyUniqueLotExt;
        }
    }
}
