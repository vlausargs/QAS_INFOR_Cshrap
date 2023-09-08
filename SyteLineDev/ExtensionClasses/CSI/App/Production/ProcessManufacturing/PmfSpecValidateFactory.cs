//PROJECT NAME: Production
//CLASS NAME: PmfSpecValidateFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfSpecValidateFactory
	{
		public IPmfSpecValidate Create(IApplicationDB appDB)
		{
			var _PmfSpecValidate = new Production.ProcessManufacturing.PmfSpecValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfSpecValidateExt = timerfactory.Create<Production.ProcessManufacturing.IPmfSpecValidate>(_PmfSpecValidate);
			
			return iPmfSpecValidateExt;
		}
	}
}
