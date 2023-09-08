//PROJECT NAME: Codes
//CLASS NAME: GetTaxCodeDefaultsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetTaxCodeDefaultsFactory
	{
		public IGetTaxCodeDefaults Create(IApplicationDB appDB)
		{
			var _GetTaxCodeDefaults = new Codes.GetTaxCodeDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTaxCodeDefaultsExt = timerfactory.Create<Codes.IGetTaxCodeDefaults>(_GetTaxCodeDefaults);
			
			return iGetTaxCodeDefaultsExt;
		}
	}
}
