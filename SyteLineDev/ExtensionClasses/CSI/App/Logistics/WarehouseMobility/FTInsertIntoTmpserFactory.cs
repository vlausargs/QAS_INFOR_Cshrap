//PROJECT NAME: Logistics
//CLASS NAME: FTInsertIntoTmpserFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTInsertIntoTmpserFactory
	{
		public IFTInsertIntoTmpser Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FTInsertIntoTmpser = new Logistics.WarehouseMobility.FTInsertIntoTmpser(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTInsertIntoTmpserExt = timerfactory.Create<Logistics.WarehouseMobility.IFTInsertIntoTmpser>(_FTInsertIntoTmpser);
			
			return iFTInsertIntoTmpserExt;
		}
	}
}
