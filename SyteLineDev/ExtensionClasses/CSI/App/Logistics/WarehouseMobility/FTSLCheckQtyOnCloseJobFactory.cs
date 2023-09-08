//PROJECT NAME: Logistics
//CLASS NAME: FTSLCheckQtyOnCloseJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLCheckQtyOnCloseJobFactory
	{
		public IFTSLCheckQtyOnCloseJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLCheckQtyOnCloseJob = new Logistics.WarehouseMobility.FTSLCheckQtyOnCloseJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLCheckQtyOnCloseJobExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLCheckQtyOnCloseJob>(_FTSLCheckQtyOnCloseJob);
			
			return iFTSLCheckQtyOnCloseJobExt;
		}
	}
}
