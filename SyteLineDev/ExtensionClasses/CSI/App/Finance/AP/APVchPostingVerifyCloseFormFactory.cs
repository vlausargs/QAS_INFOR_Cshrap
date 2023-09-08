//PROJECT NAME: CSIVendor
//CLASS NAME: APVchPostingVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class APVchPostingVerifyCloseFormFactory
    {
        public IAPVchPostingVerifyCloseForm Create(IApplicationDB appDB)
        {
            var _APVchPostingVerifyCloseForm = new APVchPostingVerifyCloseForm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPVchPostingVerifyCloseFormExt = timerfactory.Create<IAPVchPostingVerifyCloseForm>(_APVchPostingVerifyCloseForm);

            return iAPVchPostingVerifyCloseFormExt;
        }
    }
}
