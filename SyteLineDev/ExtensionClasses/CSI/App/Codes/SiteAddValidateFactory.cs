//PROJECT NAME: Codes
//CLASS NAME: SiteAddValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class SiteAddValidateFactory
	{
		public ISiteAddValidate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SiteAddValidate = new Codes.SiteAddValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSiteAddValidateExt = timerfactory.Create<Codes.ISiteAddValidate>(_SiteAddValidate);
			
			return iSiteAddValidateExt;
		}
	}
}
