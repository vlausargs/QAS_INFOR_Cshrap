//PROJECT NAME: Codes
//CLASS NAME: UpdateEuroParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class UpdateEuroParmsFactory
	{
		public IUpdateEuroParms Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateEuroParms = new Codes.UpdateEuroParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateEuroParmsExt = timerfactory.Create<Codes.IUpdateEuroParms>(_UpdateEuroParms);
			
			return iUpdateEuroParmsExt;
		}
	}
}
