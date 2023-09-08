//PROJECT NAME: Production
//CLASS NAME: PmfPnWrkProdInitUiFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PmfPnWrkProdInitUiFactory
	{
		public IPmfPnWrkProdInitUi Create(IApplicationDB appDB)
		{
			var _PmfPnWrkProdInitUi = new Production.PmfPnWrkProdInitUi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnWrkProdInitUiExt = timerfactory.Create<Production.IPmfPnWrkProdInitUi>(_PmfPnWrkProdInitUi);
			
			return iPmfPnWrkProdInitUiExt;
		}
	}
}
