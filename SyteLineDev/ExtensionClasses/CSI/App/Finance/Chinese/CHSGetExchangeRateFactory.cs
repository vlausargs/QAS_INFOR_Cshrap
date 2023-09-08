//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSGetExchangeRateFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSGetExchangeRateFactory
    {
        public ICHSGetExchangeRate Create(IApplicationDB appDB)
        {
            var _CHSGetExchangeRate = new CHSGetExchangeRate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSGetExchangeRateExt = timerfactory.Create<ICHSGetExchangeRate>(_CHSGetExchangeRate);

            return iCHSGetExchangeRateExt;
        }
    }
}

