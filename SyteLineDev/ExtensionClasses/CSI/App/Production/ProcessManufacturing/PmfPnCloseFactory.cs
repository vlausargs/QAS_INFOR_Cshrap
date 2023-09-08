//PROJECT NAME: Production
//CLASS NAME: PmfPnCloseFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnCloseFactory
	{
		public IPmfPnClose Create(IApplicationDB appDB)
		{
			var _PmfPnClose = new Production.ProcessManufacturing.PmfPnClose(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnCloseExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnClose>(_PmfPnClose);
			
			return iPmfPnCloseExt;
		}
	}
}
