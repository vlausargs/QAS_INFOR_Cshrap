//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSListOfAcctsValidFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSListOfAcctsValidFactory
    {
        public ICHSListOfAcctsValid Create(IApplicationDB appDB)
        {
            var _CHSListOfAcctsValid = new CHSListOfAcctsValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSListOfAcctsValidExt = timerfactory.Create<ICHSListOfAcctsValid>(_CHSListOfAcctsValid);

            return iCHSListOfAcctsValidExt;
        }
    }
}