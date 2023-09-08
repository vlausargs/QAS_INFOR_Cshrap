//PROJECT NAME: THLOC
//CLASS NAME: TH_InventoryMonthEndProcessFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.THLOC
{
	public class TH_InventoryMonthEndProcessFactory
	{
		public ITH_InventoryMonthEndProcess Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TH_InventoryMonthEndProcess = new THLOC.TH_InventoryMonthEndProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTH_InventoryMonthEndProcessExt = timerfactory.Create<THLOC.ITH_InventoryMonthEndProcess>(_TH_InventoryMonthEndProcess);
			
			return iTH_InventoryMonthEndProcessExt;
		}
	}
}
