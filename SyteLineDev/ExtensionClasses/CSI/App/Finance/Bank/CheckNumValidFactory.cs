//PROJECT NAME: CSIFinance
//CLASS NAME: CheckNumValidFactory.cs

using CSI.MG;

namespace CSI.Finance.Bank
{
    public class CheckNumValidFactory
    {
        public ICheckNumValid Create(IApplicationDB appDB)
        {
            var _CheckNumValid = new CheckNumValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<ICheckNumValid>(_CheckNumValid);

            return iSLCustdrftsExt;
        }
    }
}

