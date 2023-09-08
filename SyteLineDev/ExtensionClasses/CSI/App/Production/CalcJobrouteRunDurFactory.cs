//PROJECT NAME: CSIProduct
//CLASS NAME: CalcJobrouteRunDurFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CalcJobrouteRunDurFactory
    {
        public ICalcJobrouteRunDur Create(IApplicationDB appDB)
        {
            var _CalcJobrouteRunDur = new CalcJobrouteRunDur(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCalcJobrouteRunDurExt = timerfactory.Create<ICalcJobrouteRunDur>(_CalcJobrouteRunDur);

            return iCalcJobrouteRunDurExt;
        }
    }
}
