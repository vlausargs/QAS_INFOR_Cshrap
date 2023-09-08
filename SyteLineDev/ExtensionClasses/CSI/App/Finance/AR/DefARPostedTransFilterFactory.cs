//PROJECT NAME: CSICustomer
//CLASS NAME: DefARPostedTransFilterFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class DefARPostedTransFilterFactory
    {
        public IDefARPostedTransFilter Create(IApplicationDB appDB)
        {
            var _DefARPostedTransFilter = new DefARPostedTransFilter(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDefARPostedTransFilterExt = timerfactory.Create<IDefARPostedTransFilter>(_DefARPostedTransFilter);

            return iDefARPostedTransFilterExt;
        }
    }
}
