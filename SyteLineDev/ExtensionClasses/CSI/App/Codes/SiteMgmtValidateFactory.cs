//PROJECT NAME: Codes
//CLASS NAME: SiteMgmtValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class SiteMgmtValidateFactory
	{
		public ISiteMgmtValidate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SiteMgmtValidate = new Codes.SiteMgmtValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSiteMgmtValidateExt = timerfactory.Create<Codes.ISiteMgmtValidate>(_SiteMgmtValidate);
			
			return iSiteMgmtValidateExt;
		}
	}
}
