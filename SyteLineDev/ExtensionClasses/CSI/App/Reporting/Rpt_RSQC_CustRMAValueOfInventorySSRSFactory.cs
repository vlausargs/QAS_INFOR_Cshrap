//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CustRMAValueOfInventorySSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CustRMAValueOfInventorySSRSFactory
	{
		public IRpt_RSQC_CustRMAValueOfInventorySSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CustRMAValueOfInventorySSRS = new Reporting.Rpt_RSQC_CustRMAValueOfInventorySSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CustRMAValueOfInventorySSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CustRMAValueOfInventorySSRS>(_Rpt_RSQC_CustRMAValueOfInventorySSRS);
			
			return iRpt_RSQC_CustRMAValueOfInventorySSRSExt;
		}
	}
}
