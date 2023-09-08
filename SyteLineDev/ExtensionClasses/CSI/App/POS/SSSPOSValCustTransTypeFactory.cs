//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSValCustTransTypeFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSValCustTransTypeFactory
    {
        public ISSSPOSValCustTransType Create(IApplicationDB appDB)
        {
            var _SSSPOSValCustTransType = new POS.SSSPOSValCustTransType(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSValCustTransTypeExt = timerfactory.Create<POS.ISSSPOSValCustTransType>(_SSSPOSValCustTransType);

            return iSSSPOSValCustTransTypeExt;
        }
    }
}
