//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSPosM_PFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSPosM_PFactory
    {
        public ISSSPOSPosM_P Create(IApplicationDB appDB)
        {
            var _SSSPOSPosM_P = new POS.SSSPOSPosM_P(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSPosM_PExt = timerfactory.Create<POS.ISSSPOSPosM_P>(_SSSPOSPosM_P);

            return iSSSPOSPosM_PExt;
        }
    }
}
