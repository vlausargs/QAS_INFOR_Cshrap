//PROJECT NAME: Production
//CLASS NAME: PmfFmLineValidateUiFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmLineValidateUiFactory
	{
		public IPmfFmLineValidateUi Create(IApplicationDB appDB)
		{
			var _PmfFmLineValidateUi = new Production.ProcessManufacturing.PmfFmLineValidateUi(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmLineValidateUiExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmLineValidateUi>(_PmfFmLineValidateUi);
			
			return iPmfFmLineValidateUiExt;
		}
	}
}
