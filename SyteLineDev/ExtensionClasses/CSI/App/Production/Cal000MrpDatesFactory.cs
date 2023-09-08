//PROJECT NAME: CSIAPS
//CLASS NAME: Cal000MrpDatesFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class Cal000MrpDatesFactory
    {
        public ICal000MrpDates Create(IApplicationDB appDB)
        {
            var _Cal000MrpDates = new Cal000MrpDates(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCal000MrpDatesExt = timerfactory.Create<ICal000MrpDates>(_Cal000MrpDates);

            return iCal000MrpDatesExt;
        }
    }
}
