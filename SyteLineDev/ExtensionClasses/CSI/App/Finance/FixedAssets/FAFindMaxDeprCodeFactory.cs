//PROJECT NAME: CSIFinance
//CLASS NAME: FAFindMaxDeprCodeFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class FAFindMaxDeprCodeFactory
    {
        public IFAFindMaxDeprCode Create(IApplicationDB appDB)
        {
            var _FAFindMaxDeprCode = new FAFindMaxDeprCode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDeprsExt = timerfactory.Create<IFAFindMaxDeprCode>(_FAFindMaxDeprCode);

            return iSLFaDeprsExt;
        }
    }
}
