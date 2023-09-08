//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSMatchingFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSMatchingFactory
    {
        public ICHSMatching Create(IApplicationDB appDB)
        {
            var _CHSMatching = new CHSMatching(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSMatchingExt = timerfactory.Create<ICHSMatching>(_CHSMatching);

            return iCHSMatchingExt;
        }
    }
}

