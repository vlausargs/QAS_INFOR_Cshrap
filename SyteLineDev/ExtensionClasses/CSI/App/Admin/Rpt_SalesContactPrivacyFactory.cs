//PROJECT NAME: Admin
//CLASS NAME: Rpt_SalesContactPrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_SalesContactPrivacyFactory
	{
		public IRpt_SalesContactPrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalesContactPrivacy = new Admin.Rpt_SalesContactPrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalesContactPrivacyExt = timerfactory.Create<Admin.IRpt_SalesContactPrivacy>(_Rpt_SalesContactPrivacy);
			
			return iRpt_SalesContactPrivacyExt;
		}
	}
}
