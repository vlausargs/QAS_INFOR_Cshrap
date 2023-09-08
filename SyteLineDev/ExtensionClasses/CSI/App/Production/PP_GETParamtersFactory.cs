//PROJECT NAME: CSIProduct
//CLASS NAME: PP_GETParamtersFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PP_GETParamtersFactory
	{
		public IPP_GETParamters Create(IApplicationDB appDB)
		{
			var _PP_GETParamters = new Production.PP_GETParamters(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_GETParamtersExt = timerfactory.Create<Production.IPP_GETParamters>(_PP_GETParamters);
			
			return iPP_GETParamtersExt;
		}
	}
}
