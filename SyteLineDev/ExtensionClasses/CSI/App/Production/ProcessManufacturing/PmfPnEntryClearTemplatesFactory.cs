//PROJECT NAME: Production
//CLASS NAME: PmfPnEntryClearTemplatesFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnEntryClearTemplatesFactory
	{
		public IPmfPnEntryClearTemplates Create(IApplicationDB appDB)
		{
			var _PmfPnEntryClearTemplates = new Production.ProcessManufacturing.PmfPnEntryClearTemplates(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnEntryClearTemplatesExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnEntryClearTemplates>(_PmfPnEntryClearTemplates);
			
			return iPmfPnEntryClearTemplatesExt;
		}
	}
}
