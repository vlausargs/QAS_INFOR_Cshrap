//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSReverseFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSReverseFactory
    {
        public ISSSPOSReverse Create(IApplicationDB appDB)
        {
            var _SSSPOSReverse = new POS.SSSPOSReverse(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSReverseExt = timerfactory.Create<POS.ISSSPOSReverse>(_SSSPOSReverse);

            return iSSSPOSReverseExt;
        }
    }
}
