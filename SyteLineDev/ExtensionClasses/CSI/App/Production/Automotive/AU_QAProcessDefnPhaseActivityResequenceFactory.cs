//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessDefnPhaseActivityResequenceFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
    public class AU_QAProcessDefnPhaseActivityResequenceFactory
    {
        public IAU_QAProcessDefnPhaseActivityResequence Create(IApplicationDB appDB)
        {
            var _AU_QAProcessDefnPhaseActivityResequence = new AU_QAProcessDefnPhaseActivityResequence(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_QAProcessDefnPhaseActivityResequenceExt = timerfactory.Create<IAU_QAProcessDefnPhaseActivityResequence>(_AU_QAProcessDefnPhaseActivityResequence);

            return iAU_QAProcessDefnPhaseActivityResequenceExt;
        }
    }
}
