//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdChgDomAmtAppliedFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtdChgDomAmtAppliedFactory
    {
        public IArpmtdChgDomAmtApplied Create(IApplicationDB appDB)
        {
            var _ArpmtdChgDomAmtApplied = new ArpmtdChgDomAmtApplied(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtdChgDomAmtAppliedExt = timerfactory.Create<IArpmtdChgDomAmtApplied>(_ArpmtdChgDomAmtApplied);

            return iArpmtdChgDomAmtAppliedExt;
        }
    }
}
