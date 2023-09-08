//PROJECT NAME: Logistics
//CLASS NAME: FTSLQCSGetTestEachStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLQCSGetTestEachStatusFactory
	{
		public IFTSLQCSGetTestEachStatus Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLQCSGetTestEachStatus = new Logistics.WarehouseMobility.FTSLQCSGetTestEachStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLQCSGetTestEachStatusExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLQCSGetTestEachStatus>(_FTSLQCSGetTestEachStatus);
			
			return iFTSLQCSGetTestEachStatusExt;
		}
	}
}
