//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryOrdInitUiFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnEntryOrdInitUiFactory
	{
		public IPmfPnEntryOrdInitUi Create(IApplicationDB appDB)
		{
			var _PmfPnEntryOrdInitUi = new Production.ProcessManufacturing.PmfPnEntryOrdInitUi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnEntryOrdInitUiExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnEntryOrdInitUi>(_PmfPnEntryOrdInitUi);
			
			return iPmfPnEntryOrdInitUiExt;
		}
	}
}
