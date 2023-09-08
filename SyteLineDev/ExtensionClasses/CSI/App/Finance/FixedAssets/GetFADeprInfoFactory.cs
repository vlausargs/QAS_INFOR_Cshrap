//PROJECT NAME: CSIFinance
//CLASS NAME: GetFADeprInfoFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class GetFADeprInfoFactory
    {
        public IGetFADeprInfo Create(IApplicationDB appDB)
        {
            var _GetFADeprInfo = new GetFADeprInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFamastersExt = timerfactory.Create<IGetFADeprInfo>(_GetFADeprInfo);

            return iSLFamastersExt;
        }
    }
}
