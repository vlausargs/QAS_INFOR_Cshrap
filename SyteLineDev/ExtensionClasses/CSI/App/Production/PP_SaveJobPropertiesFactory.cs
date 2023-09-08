//PROJECT NAME: Production
//CLASS NAME: PP_SaveJobPropertiesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_SaveJobPropertiesFactory
	{
		public IPP_SaveJobProperties Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_SaveJobProperties = new Production.PP_SaveJobProperties(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_SaveJobPropertiesExt = timerfactory.Create<Production.IPP_SaveJobProperties>(_PP_SaveJobProperties);
			
			return iPP_SaveJobPropertiesExt;
		}
	}
}
