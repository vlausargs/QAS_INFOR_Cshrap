//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveDomAmtFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtLeaveDomAmtFactory
    {
        public IArpmtLeaveDomAmt Create(IApplicationDB appDB)
        {
            var _ArpmtLeaveDomAmt = new ArpmtLeaveDomAmt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtLeaveDomAmtExt = timerfactory.Create<IArpmtLeaveDomAmt>(_ArpmtLeaveDomAmt);

            return iArpmtLeaveDomAmtExt;
        }
    }
}
