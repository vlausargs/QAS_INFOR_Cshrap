//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSLoadCurrencyNameFactory.cs

using CSI.MG;

namespace CSI.Finance.Chinese
{
    public class CHSLoadCurrencyNameFactory
    {
        public ICHSLoadCurrencyName Create(IApplicationDB appDB)
        {
            var _CHSLoadCurrencyName = new CHSLoadCurrencyName(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCHSLoadCurrencyNameExt = timerfactory.Create<ICHSLoadCurrencyName>(_CHSLoadCurrencyName);

            return iCHSLoadCurrencyNameExt;
        }
    }
}