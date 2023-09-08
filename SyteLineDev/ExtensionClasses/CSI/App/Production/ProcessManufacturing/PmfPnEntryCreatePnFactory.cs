//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryCreatePnFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnEntryCreatePnFactory
	{
		public IPmfPnEntryCreatePn Create(IApplicationDB appDB)
		{
			var _PmfPnEntryCreatePn = new Production.ProcessManufacturing.PmfPnEntryCreatePn(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnEntryCreatePnExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnEntryCreatePn>(_PmfPnEntryCreatePn);
			
			return iPmfPnEntryCreatePnExt;
		}
	}
}
