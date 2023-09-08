//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryValidateUiFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnEntryValidateUiFactory
	{
		public IPmfPnEntryValidateUi Create(IApplicationDB appDB)
		{
			var _PmfPnEntryValidateUi = new Production.ProcessManufacturing.PmfPnEntryValidateUi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnEntryValidateUiExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnEntryValidateUi>(_PmfPnEntryValidateUi);
			
			return iPmfPnEntryValidateUiExt;
		}
	}
}
