//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSQtyOnHandCheckFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSQtyOnHandCheckFactory
    {
        public ISSSPOSQtyOnHandCheck Create(IApplicationDB appDB)
        {
            var _SSSPOSQtyOnHandCheck = new POS.SSSPOSQtyOnHandCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSQtyOnHandCheckExt = timerfactory.Create<POS.ISSSPOSQtyOnHandCheck>(_SSSPOSQtyOnHandCheck);

            return iSSSPOSQtyOnHandCheckExt;
        }
    }
}
