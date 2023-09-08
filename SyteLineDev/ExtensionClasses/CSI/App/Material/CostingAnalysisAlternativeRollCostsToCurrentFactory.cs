//PROJECT NAME: CSIMaterial
//CLASS NAME: CostingAnalysisAlternativeRollCostsToCurrentFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class CostingAnalysisAlternativeRollCostsToCurrentFactory
    {
        public ICostingAnalysisAlternativeRollCostsToCurrent Create(IApplicationDB appDB)
        {
            var _CostingAnalysisAlternativeRollCostsToCurrent = new CostingAnalysisAlternativeRollCostsToCurrent(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCostingAnalysisAlternativeRollCostsToCurrenExt = timerfactory.Create<ICostingAnalysisAlternativeRollCostsToCurrent>(_CostingAnalysisAlternativeRollCostsToCurrent);

            return iCostingAnalysisAlternativeRollCostsToCurrenExt;
        }
    }
}
