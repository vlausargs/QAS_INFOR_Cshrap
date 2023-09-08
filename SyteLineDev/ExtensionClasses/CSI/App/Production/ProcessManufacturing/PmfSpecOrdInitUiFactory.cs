//PROJECT NAME: Production
//CLASS NAME: PmfSpecOrdInitUiFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfSpecOrdInitUiFactory
	{
		public IPmfSpecOrdInitUi Create(IApplicationDB appDB)
		{
			var _PmfSpecOrdInitUi = new Production.ProcessManufacturing.PmfSpecOrdInitUi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfSpecOrdInitUiExt = timerfactory.Create<Production.ProcessManufacturing.IPmfSpecOrdInitUi>(_PmfSpecOrdInitUi);
			
			return iPmfSpecOrdInitUiExt;
		}
	}
}
