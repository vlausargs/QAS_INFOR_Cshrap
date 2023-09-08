//PROJECT NAME: Production
//CLASS NAME: GeneratePsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class GeneratePsFactory
	{
		public IGeneratePs Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GeneratePs = new Production.GeneratePs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGeneratePsExt = timerfactory.Create<Production.IGeneratePs>(_GeneratePs);
			
			return iGeneratePsExt;
		}
	}
}
