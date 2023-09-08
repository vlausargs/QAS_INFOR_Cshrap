//PROJECT NAME: CSIFinance
//CLASS NAME: FaUpdPreFetchFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class FaUpdPreFetchFactory
    {
        public IFaUpdPreFetch Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _FaUpdPreFetch = new FaUpdPreFetch(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDeprsExt = timerfactory.Create<IFaUpdPreFetch>(_FaUpdPreFetch);

            return iSLFaDeprsExt;
        }
    }
}