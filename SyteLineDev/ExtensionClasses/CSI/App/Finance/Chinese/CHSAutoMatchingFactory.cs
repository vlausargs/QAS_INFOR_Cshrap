//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSAutoMatchingFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSAutoMatchingFactory
    {
        public ICHSAutoMatching Create(IApplicationDB appDB)
        {
            var _CHSAutoMatching = new CHSAutoMatching(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSAutoMatchingExt = timerfactory.Create<ICHSAutoMatching>(_CHSAutoMatching);

            return iCHSAutoMatchingExt;
        }
    }
}
