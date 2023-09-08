//PROJECT NAME: CSICustomer
//CLASS NAME: InvoicesDebitAndCreditMemosFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class InvoicesDebitAndCreditMemosFactory
    {
        public IInvoicesDebitAndCreditMemos Create(IApplicationDB appDB)
        {
            var _InvoicesDebitAndCreditMemos = new InvoicesDebitAndCreditMemos(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInvoicesDebitAndCreditMemosExt = timerfactory.Create<IInvoicesDebitAndCreditMemos>(_InvoicesDebitAndCreditMemos);

            return iInvoicesDebitAndCreditMemosExt;
        }
    }
}
