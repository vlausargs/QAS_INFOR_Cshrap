//PROJECT NAME: Admin
//CLASS NAME: Rpt_DropShipToPrivacyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class Rpt_DropShipToPrivacyFactory
	{
		public IRpt_DropShipToPrivacy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DropShipToPrivacy = new Admin.Rpt_DropShipToPrivacy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DropShipToPrivacyExt = timerfactory.Create<Admin.IRpt_DropShipToPrivacy>(_Rpt_DropShipToPrivacy);
			
			return iRpt_DropShipToPrivacyExt;
		}
	}
}
