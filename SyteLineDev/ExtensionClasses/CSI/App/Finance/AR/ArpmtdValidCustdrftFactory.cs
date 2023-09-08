//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidCustdrftFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArpmtdValidCustdrftFactory
    {
        public IArpmtdValidCustdrft Create(IApplicationDB appDB)
        {
            var _ArpmtdValidCustdrft = new ArpmtdValidCustdrft(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArpmtdValidCustdrftExt = timerfactory.Create<IArpmtdValidCustdrft>(_ArpmtdValidCustdrft);

            return iArpmtdValidCustdrftExt;
        }
    }
}
