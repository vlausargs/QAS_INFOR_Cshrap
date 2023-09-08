//PROJECT NAME: Production
//CLASS NAME: PmfFmResizeFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmResizeFactory
	{
		public IPmfFmResize Create(IApplicationDB appDB)
		{
			var _PmfFmResize = new Production.ProcessManufacturing.PmfFmResize(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmResizeExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmResize>(_PmfFmResize);
			
			return iPmfFmResizeExt;
		}
	}
}
