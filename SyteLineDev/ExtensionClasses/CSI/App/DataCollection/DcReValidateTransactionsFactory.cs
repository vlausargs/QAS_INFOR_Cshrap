//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcReValidateTransactionsFactory.cs

using CSI.MG;

namespace CSI.DataCollection
{
    public class DcReValidateTransactionsFactory
    {
        public IDcReValidateTransactions Create(IApplicationDB appDB)
        {
            var _DcReValidateTransactions = new DcReValidateTransactions(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDcReValidateTransactionsExt = timerfactory.Create<IDcReValidateTransactions>(_DcReValidateTransactions);

            return iDcReValidateTransactionsExt;
        }
    }
}

