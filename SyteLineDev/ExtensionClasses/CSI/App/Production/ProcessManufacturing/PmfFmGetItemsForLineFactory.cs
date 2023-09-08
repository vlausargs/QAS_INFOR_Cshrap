//PROJECT NAME: Production
//CLASS NAME: PmfFmGetItemsForLineFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmGetItemsForLineFactory
	{
		public IPmfFmGetItemsForLine Create(IApplicationDB appDB)
		{
			var _PmfFmGetItemsForLine = new Production.ProcessManufacturing.PmfFmGetItemsForLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmGetItemsForLineExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmGetItemsForLine>(_PmfFmGetItemsForLine);
			
			return iPmfFmGetItemsForLineExt;
		}
	}
}
