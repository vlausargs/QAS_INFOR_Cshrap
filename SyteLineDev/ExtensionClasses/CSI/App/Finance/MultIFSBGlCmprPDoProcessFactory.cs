//PROJECT NAME: CSIFinance
//CLASS NAME: MultIFSBGlCmprPDoProcessFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultIFSBGlCmprPDoProcessFactory
    {
        public IMultIFSBGlCmprPDoProcess Create(IApplicationDB appDB)
        {
            var _MultIFSBGlCmprPDoProcess = new MultIFSBGlCmprPDoProcess(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbLedgersExt = timerfactory.Create<IMultIFSBGlCmprPDoProcess>(_MultIFSBGlCmprPDoProcess);

            return iSLFsbLedgersExt;
        }
    }
}
