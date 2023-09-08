//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSConPostInvFactory.cs

using CSI.MG;

namespace CSI.POS
{
    public class SSSPOSConPostInvFactory
    {
        public ISSSPOSConPostInv Create(IApplicationDB appDB)
        {
            var _SSSPOSConPostInv = new POS.SSSPOSConPostInv(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSPOSConPostInvExt = timerfactory.Create<POS.ISSSPOSConPostInv>(_SSSPOSConPostInv);

            return iSSSPOSConPostInvExt;
        }
    }
}
