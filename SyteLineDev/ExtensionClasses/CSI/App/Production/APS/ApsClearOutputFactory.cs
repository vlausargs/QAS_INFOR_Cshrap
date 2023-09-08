//PROJECT NAME: CSIAPS
//CLASS NAME: ApsClearOutputFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class ApsClearOutputFactory
    {
        public IApsClearOutput Create(IApplicationDB appDB)
        {
            var _ApsClearOutput = new ApsClearOutput(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApsClearOutputExt = timerfactory.Create<IApsClearOutput>(_ApsClearOutput);

            return iApsClearOutputExt;
        }
    }
}
