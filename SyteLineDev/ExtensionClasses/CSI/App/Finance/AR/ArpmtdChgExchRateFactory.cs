//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdChgExchRateFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtdChgExchRateFactory
    {
        public IArpmtdChgExchRate Create(IApplicationDB appDB)
        {
            var _ArpmtdChgExchRate = new ArpmtdChgExchRate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtdChgExchRateExt = timerfactory.Create<IArpmtdChgExchRate>(_ArpmtdChgExchRate);

            return iArpmtdChgExchRateExt;
        }
    }
}
