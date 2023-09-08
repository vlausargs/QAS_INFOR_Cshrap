//PROJECT NAME: Logistics
//CLASS NAME: FTSLJobEfficiencyCalculationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLJobEfficiencyCalculationFactory
	{
		public IFTSLJobEfficiencyCalculation Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLJobEfficiencyCalculation = new Logistics.WarehouseMobility.FTSLJobEfficiencyCalculation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLJobEfficiencyCalculationExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLJobEfficiencyCalculation>(_FTSLJobEfficiencyCalculation);
			
			return iFTSLJobEfficiencyCalculationExt;
		}
	}
}
