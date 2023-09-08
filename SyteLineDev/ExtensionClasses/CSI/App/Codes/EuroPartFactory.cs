//PROJECT NAME: Codes
//CLASS NAME: EuroPartFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class EuroPartFactory
	{
		public IEuroPart Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EuroPart = new Codes.EuroPart(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEuroPartExt = timerfactory.Create<Codes.IEuroPart>(_EuroPart);
			
			return iEuroPartExt;
		}
	}
}
