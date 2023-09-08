//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemVerifyCloseFormFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArPostRemVerifyCloseFormFactory
    {
        public IArPostRemVerifyCloseForm Create(IApplicationDB appDB)
        {
            var _ArPostRemVerifyCloseForm = new ArPostRemVerifyCloseForm(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<IArPostRemVerifyCloseForm>(_ArPostRemVerifyCloseForm);

            return iSLCustdrftsExt;
        }
    }
}

