//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSLoadBankReconFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSLoadBankReconFactory
    {
        public ICHSLoadBankRecon Create(IApplicationDB appDB)
        {
            var _CHSLoadBankRecon = new CHSLoadBankRecon(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSLoadBankReconExt = timerfactory.Create<ICHSLoadBankRecon>(_CHSLoadBankRecon);

            return iCHSLoadBankReconExt;
        }
    }
}

