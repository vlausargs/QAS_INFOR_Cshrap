//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSMatlGetDiscFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSMatlGetDiscFactory
    {
        public ISSSPOSMatlGetDisc Create(IApplicationDB appDB)
        {
            var _SSSPOSMatlGetDisc = new POS.SSSPOSMatlGetDisc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSMatlGetDiscExt = timerfactory.Create<POS.ISSSPOSMatlGetDisc>(_SSSPOSMatlGetDisc);

            return iSSSPOSMatlGetDiscExt;
        }
    }
}
