//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBPertotFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBPertotFactory
    {
        public IMultiFSBPertot Create(IApplicationDB appDB)
        {
            var _MultiFSBPertot = new MultiFSBPertot(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMultiFSBPertotExt = timerfactory.Create<IMultiFSBPertot>(_MultiFSBPertot);

            return iMultiFSBPertotExt;
        }
    }
}

