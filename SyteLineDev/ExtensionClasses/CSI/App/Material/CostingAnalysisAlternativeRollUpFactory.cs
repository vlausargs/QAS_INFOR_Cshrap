//PROJECT NAME: CSIMaterial
//CLASS NAME: CostingAnalysisAlternativeRollFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CostingAnalysisAlternativeRollFactory
    {
        public ICostingAnalysisAlternativeRoll Create(IApplicationDB appDB)
        {
            var _CostingAnalysisAlternativeRoll = new Material.CostingAnalysisAlternativeRoll(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCostingAnalysisAlternativeRollExt = timerfactory.Create<Material.ICostingAnalysisAlternativeRoll>(_CostingAnalysisAlternativeRoll);

            return iCostingAnalysisAlternativeRollExt;
        }
    }
}
