//PROJECT NAME: CSIAPS
//CLASS NAME: ApsFreezeSchedOpFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsFreezeSchedOpFactory
    {
        public IApsFreezeSchedOp Create(IApplicationDB appDB)
        {
            var _ApsFreezeSchedOp = new ApsFreezeSchedOp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsFreezeSchedOpExt = timerfactory.Create<IApsFreezeSchedOp>(_ApsFreezeSchedOp);

            return iApsFreezeSchedOpExt;
        }
    }
}
