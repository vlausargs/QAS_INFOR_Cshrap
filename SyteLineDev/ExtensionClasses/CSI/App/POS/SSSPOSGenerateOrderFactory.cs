//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSGenerateOrderFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSGenerateOrderFactory
    {
        public ISSSPOSGenerateOrder Create(IApplicationDB appDB)
        {
            var _SSSPOSGenerateOrder = new POS.SSSPOSGenerateOrder(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSGenerateOrderExt = timerfactory.Create<POS.ISSSPOSGenerateOrder>(_SSSPOSGenerateOrder);

            return iSSSPOSGenerateOrderExt;
        }
    }
}
