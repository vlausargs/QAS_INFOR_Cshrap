//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_QAProcessPhaseResequenceSFactory.cs

using CSI.MG;

namespace CSI.Production.Automotive
{
    public class AU_QAProcessPhaseResequenceSFactory
    {
        public IAU_QAProcessPhaseResequenceS Create(IApplicationDB appDB)
        {
            var _AU_QAProcessPhaseResequenceS = new Production.Automotive.AU_QAProcessPhaseResequenceS(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAU_QAProcessPhaseResequenceSExt = timerfactory.Create<Production.Automotive.IAU_QAProcessPhaseResequenceS>(_AU_QAProcessPhaseResequenceS);

            return iAU_QAProcessPhaseResequenceSExt;
        }
    }
}
