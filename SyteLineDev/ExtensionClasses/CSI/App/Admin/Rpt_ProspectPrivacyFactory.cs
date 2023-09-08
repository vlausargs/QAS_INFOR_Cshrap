//PROJECT NAME: Admin
//CLASS NAME: Rpt_ProspectPrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_ProspectPrivacyFactory
	{
		public IRpt_ProspectPrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProspectPrivacy = new Admin.Rpt_ProspectPrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProspectPrivacyExt = timerfactory.Create<Admin.IRpt_ProspectPrivacy>(_Rpt_ProspectPrivacy);
			
			return iRpt_ProspectPrivacyExt;
		}
	}
}
