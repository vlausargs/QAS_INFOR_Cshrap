//PROJECT NAME: Logistics
//CLASS NAME: FTSLCheckBackflushNeededFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLCheckBackflushNeededFactory
	{
		public IFTSLCheckBackflushNeeded Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLCheckBackflushNeeded = new Logistics.WarehouseMobility.FTSLCheckBackflushNeeded(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLCheckBackflushNeededExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLCheckBackflushNeeded>(_FTSLCheckBackflushNeeded);
			
			return iFTSLCheckBackflushNeededExt;
		}
	}
}
