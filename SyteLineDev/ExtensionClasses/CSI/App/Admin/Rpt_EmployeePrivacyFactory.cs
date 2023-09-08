//PROJECT NAME: Admin
//CLASS NAME: Rpt_EmployeePrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_EmployeePrivacyFactory
	{
		public IRpt_EmployeePrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EmployeePrivacy = new Admin.Rpt_EmployeePrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EmployeePrivacyExt = timerfactory.Create<Admin.IRpt_EmployeePrivacy>(_Rpt_EmployeePrivacy);
			
			return iRpt_EmployeePrivacyExt;
		}
	}
}
