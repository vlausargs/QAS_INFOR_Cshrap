//PROJECT NAME: Production
//CLASS NAME: PmfPnSizeProdFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnSizeProdFactory
	{
		public IPmfPnSizeProd Create(IApplicationDB appDB)
		{
			var _PmfPnSizeProd = new Production.ProcessManufacturing.PmfPnSizeProd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnSizeProdExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnSizeProd>(_PmfPnSizeProd);
			
			return iPmfPnSizeProdExt;
		}
	}
}
