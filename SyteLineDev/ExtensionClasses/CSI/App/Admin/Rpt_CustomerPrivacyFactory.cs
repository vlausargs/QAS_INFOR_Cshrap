//PROJECT NAME: Admin
//CLASS NAME: Rpt_CustomerPrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_CustomerPrivacyFactory
	{
		public IRpt_CustomerPrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerPrivacy = new Admin.Rpt_CustomerPrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerPrivacyExt = timerfactory.Create<Admin.IRpt_CustomerPrivacy>(_Rpt_CustomerPrivacy);
			
			return iRpt_CustomerPrivacyExt;
		}
	}
}
