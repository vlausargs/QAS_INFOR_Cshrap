//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetDelaysFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
    public class CLM_ApsGetDelaysFactory
    {
        public ICLM_ApsGetDelays Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ApsGetDelays = new CLM_ApsGetDelays(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetDelaysExt = timerfactory.Create<ICLM_ApsGetDelays>(_CLM_ApsGetDelays);

            return iCLM_ApsGetDelaysExt;
        }
    }
}
