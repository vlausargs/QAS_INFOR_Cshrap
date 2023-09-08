//PROJECT NAME: Admin
//CLASS NAME: Rpt_VendorPrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_VendorPrivacyFactory
	{
		public IRpt_VendorPrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VendorPrivacy = new Admin.Rpt_VendorPrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VendorPrivacyExt = timerfactory.Create<Admin.IRpt_VendorPrivacy>(_Rpt_VendorPrivacy);
			
			return iRpt_VendorPrivacyExt;
		}
	}
}
