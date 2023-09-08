//PROJECT NAME: Admin
//CLASS NAME: Rpt_PartnerPrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_PartnerPrivacyFactory
	{
		public IRpt_PartnerPrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PartnerPrivacy = new Admin.Rpt_PartnerPrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PartnerPrivacyExt = timerfactory.Create<Admin.IRpt_PartnerPrivacy>(_Rpt_PartnerPrivacy);
			
			return iRpt_PartnerPrivacyExt;
		}
	}
}
