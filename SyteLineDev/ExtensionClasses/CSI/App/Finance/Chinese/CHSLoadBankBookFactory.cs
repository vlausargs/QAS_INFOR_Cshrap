//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSLoadBankBookFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSLoadBankBookFactory
    {
        public ICHSLoadBankBook Create(IApplicationDB appDB)
        {
            var _CHSLoadBankBook = new CHSLoadBankBook(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSLoadBankBookExt = timerfactory.Create<ICHSLoadBankBook>(_CHSLoadBankBook);

            return iCHSLoadBankBookExt;
        }
    }
}

