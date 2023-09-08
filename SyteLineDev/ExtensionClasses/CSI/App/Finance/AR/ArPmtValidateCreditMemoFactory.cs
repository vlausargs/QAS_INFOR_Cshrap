//PROJECT NAME: CSICustomer
//CLASS NAME: ArPmtValidateCreditMemoFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArPmtValidateCreditMemoFactory
    {
        public IArPmtValidateCreditMemo Create(IApplicationDB appDB)
        {
            var _ArPmtValidateCreditMemo = new ArPmtValidateCreditMemo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArPmtValidateCreditMemoExt = timerfactory.Create<IArPmtValidateCreditMemo>(_ArPmtValidateCreditMemo);

            return iArPmtValidateCreditMemoExt;
        }
    }
}
