//PROJECT NAME: Production
//CLASS NAME: PmfPnValidateCloseFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnValidateCloseFactory
	{
		public IPmfPnValidateClose Create(IApplicationDB appDB)
		{
			var _PmfPnValidateClose = new Production.ProcessManufacturing.PmfPnValidateClose(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnValidateCloseExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnValidateClose>(_PmfPnValidateClose);
			
			return iPmfPnValidateCloseExt;
		}
	}
}
