//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdChgDomDiscAmtFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtdChgDomDiscAmtFactory
    {
        public IArpmtdChgDomDiscAmt Create(IApplicationDB appDB)
        {
            var _ArpmtdChgDomDiscAmt = new ArpmtdChgDomDiscAmt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtdChgDomDiscAmtExt = timerfactory.Create<IArpmtdChgDomDiscAmt>(_ArpmtdChgDomDiscAmt);

            return iArpmtdChgDomDiscAmtExt;
        }
    }
}
