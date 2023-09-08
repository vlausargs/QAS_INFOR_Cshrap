//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetPSJITInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetPSJITInfoFactory
	{
		public IFTSLGetPSJITInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTSLGetPSJITInfo = new Logistics.WarehouseMobility.FTSLGetPSJITInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetPSJITInfoExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetPSJITInfo>(_FTSLGetPSJITInfo);
			
			return iFTSLGetPSJITInfoExt;
		}
	}
}
