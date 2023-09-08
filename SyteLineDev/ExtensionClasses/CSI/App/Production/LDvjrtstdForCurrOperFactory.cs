//PROJECT NAME: CSIProduct
//CLASS NAME: LDvjrtstdForCurrOperFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class LDvjrtstdForCurrOperFactory
    {
        public ILDvjrtstdForCurrOper Create(IApplicationDB appDB)
        {
            var _LDvjrtstdForCurrOper = new LDvjrtstdForCurrOper(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iLDvjrtstdForCurrOperExt = timerfactory.Create<ILDvjrtstdForCurrOper>(_LDvjrtstdForCurrOper);

            return iLDvjrtstdForCurrOperExt;
        }
    }
}
