//PROJECT NAME: CSIFinance
//CLASS NAME: GlCmprPInitializeFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class GlCmprPInitializeFactory
    {
        public IGlCmprPInitialize Create(IApplicationDB appDB)
        {
            var _GlCmprPInitialize = new GlCmprPInitialize(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLLedgersExt = timerfactory.Create<IGlCmprPInitialize>(_GlCmprPInitialize);

            return iSLLedgersExt;
        }
    }
}

