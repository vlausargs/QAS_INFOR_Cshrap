//PROJECT NAME: Admin
//CLASS NAME: Rpt_ApplicantPrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_ApplicantPrivacyFactory
	{
		public IRpt_ApplicantPrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ApplicantPrivacy = new Admin.Rpt_ApplicantPrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ApplicantPrivacyExt = timerfactory.Create<Admin.IRpt_ApplicantPrivacy>(_Rpt_ApplicantPrivacy);
			
			return iRpt_ApplicantPrivacyExt;
		}
	}
}
