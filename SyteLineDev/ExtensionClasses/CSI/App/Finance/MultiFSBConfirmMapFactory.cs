//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBConfirmMapFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBConfirmMapFactory
    {
        public IMultiFSBConfirmMap Create(IApplicationDB appDB)
        {
            var _MultiFSBConfirmMap = new MultiFSBConfirmMap(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbChartOfAcctsExt = timerfactory.Create<IMultiFSBConfirmMap>(_MultiFSBConfirmMap);

            return iSLFsbChartOfAcctsExt;
        }
    }
}
