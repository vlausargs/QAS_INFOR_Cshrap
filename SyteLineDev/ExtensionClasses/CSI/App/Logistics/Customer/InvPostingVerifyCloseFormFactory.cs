//PROJECT NAME: CSICustomer
//CLASS NAME: InvPostingVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class InvPostingVerifyCloseFormFactory
    {
        public IInvPostingVerifyCloseForm Create(IApplicationDB appDB)
        {
            var _InvPostingVerifyCloseForm = new InvPostingVerifyCloseForm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iInvPostingVerifyCloseFormExt = timerfactory.Create<IInvPostingVerifyCloseForm>(_InvPostingVerifyCloseForm);

            return iInvPostingVerifyCloseFormExt;
        }
    }
}
