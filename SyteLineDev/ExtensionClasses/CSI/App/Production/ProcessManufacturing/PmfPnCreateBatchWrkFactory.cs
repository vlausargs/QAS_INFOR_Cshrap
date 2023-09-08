//PROJECT NAME: Production
//CLASS NAME: PmfPnCreateBatchWrkFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnCreateBatchWrkFactory
	{
		public IPmfPnCreateBatchWrk Create(IApplicationDB appDB)
		{
			var _PmfPnCreateBatchWrk = new Production.ProcessManufacturing.PmfPnCreateBatchWrk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnCreateBatchWrkExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnCreateBatchWrk>(_PmfPnCreateBatchWrk);
			
			return iPmfPnCreateBatchWrkExt;
		}
	}
}
