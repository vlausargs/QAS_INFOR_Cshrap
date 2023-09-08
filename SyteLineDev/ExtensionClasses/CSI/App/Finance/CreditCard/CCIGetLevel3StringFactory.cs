//PROJECT NAME: Finance
//CLASS NAME: CCIGetLevel3StringFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
    public class CCIGetLevel3StringFactory
    {
        public ICCIGetLevel3String Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            
            var _CCIGetLevel3String = new Finance.CreditCard.CCIGetLevel3String(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCCIGetLevel3StringExt = timerfactory.Create<Finance.CreditCard.ICCIGetLevel3String>(_CCIGetLevel3String);

            return iCCIGetLevel3StringExt;
        }
    }
}
