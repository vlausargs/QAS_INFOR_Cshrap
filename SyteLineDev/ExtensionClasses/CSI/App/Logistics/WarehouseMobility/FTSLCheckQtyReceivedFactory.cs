//PROJECT NAME: Logistics
//CLASS NAME: FTSLCheckQtyReceivedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLCheckQtyReceivedFactory
	{
		public IFTSLCheckQtyReceived Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLCheckQtyReceived = new Logistics.WarehouseMobility.FTSLCheckQtyReceived(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLCheckQtyReceivedExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLCheckQtyReceived>(_FTSLCheckQtyReceived);
			
			return iFTSLCheckQtyReceivedExt;
		}
	}
}
