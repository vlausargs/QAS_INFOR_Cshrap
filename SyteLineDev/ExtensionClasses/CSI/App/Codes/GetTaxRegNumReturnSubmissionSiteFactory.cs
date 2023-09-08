//PROJECT NAME: Codes
//CLASS NAME: GetTaxRegNumReturnSubmissionSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class GetTaxRegNumReturnSubmissionSiteFactory
	{
		public IGetTaxRegNumReturnSubmissionSite Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetTaxRegNumReturnSubmissionSite = new Codes.GetTaxRegNumReturnSubmissionSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTaxRegNumReturnSubmissionSiteExt = timerfactory.Create<Codes.IGetTaxRegNumReturnSubmissionSite>(_GetTaxRegNumReturnSubmissionSite);
			
			return iGetTaxRegNumReturnSubmissionSiteExt;
		}
	}
}
