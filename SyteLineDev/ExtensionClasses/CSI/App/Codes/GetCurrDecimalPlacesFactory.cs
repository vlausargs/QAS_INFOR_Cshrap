//PROJECT NAME: Codes
//CLASS NAME: GetCurrDecimalPlacesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GetCurrDecimalPlacesFactory
	{
		public IGetCurrDecimalPlaces Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCurrDecimalPlaces = new Codes.GetCurrDecimalPlaces(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCurrDecimalPlacesExt = timerfactory.Create<Codes.IGetCurrDecimalPlaces>(_GetCurrDecimalPlaces);
			
			return iGetCurrDecimalPlacesExt;
		}
	}
}
