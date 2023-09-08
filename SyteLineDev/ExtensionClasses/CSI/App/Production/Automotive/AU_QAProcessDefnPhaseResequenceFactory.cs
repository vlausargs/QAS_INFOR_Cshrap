//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessDefnPhaseResequenceFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
    public class AU_QAProcessDefnPhaseResequenceFactory
    {
        public IAU_QAProcessDefnPhaseResequence Create(IApplicationDB appDB)
        {
            var _AU_QAProcessDefnPhaseResequence = new AU_QAProcessDefnPhaseResequence(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_QAProcessDefnPhaseResequenceExt = timerfactory.Create<IAU_QAProcessDefnPhaseResequence>(_AU_QAProcessDefnPhaseResequence);

            return iAU_QAProcessDefnPhaseResequenceExt;
        }
    }
}
