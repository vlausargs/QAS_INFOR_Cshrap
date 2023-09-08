//PROJECT NAME: CSIProduct
//CLASS NAME: ApsSetSequenceDatesFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class ApsSetSequenceDatesFactory
    {
        public IApsSetSequenceDates Create(IApplicationDB appDB)
        {
            var _ApsSetSequenceDates = new ApsSetSequenceDates(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsSetSequenceDatesExt = timerfactory.Create<IApsSetSequenceDates>(_ApsSetSequenceDates);

            return iApsSetSequenceDatesExt;
        }
    }
}
