//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessPhaseActivityResequenceFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
    public class AU_QAProcessPhaseActivityResequenceFactory
    {
        public IAU_QAProcessPhaseActivityResequence Create(IApplicationDB appDB)
        {
            var _AU_QAProcessPhaseActivityResequence = new AU_QAProcessPhaseActivityResequence(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_QAProcessPhaseActivityResequenceExt = timerfactory.Create<IAU_QAProcessPhaseActivityResequence>(_AU_QAProcessPhaseActivityResequence);

            return iAU_QAProcessPhaseActivityResequenceExt;
        }
    }
}

