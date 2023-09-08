//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryInitUiFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnEntryInitUiFactory
	{
		public IPmfPnEntryInitUi Create(IApplicationDB appDB)
		{
			var _PmfPnEntryInitUi = new Production.ProcessManufacturing.PmfPnEntryInitUi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnEntryInitUiExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnEntryInitUi>(_PmfPnEntryInitUi);
			
			return iPmfPnEntryInitUiExt;
		}
	}
}
