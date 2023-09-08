//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CustInspecStatSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CustInspecStatSSRSFactory
	{
		public IRpt_RSQC_CustInspecStatSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CustInspecStatSSRS = new Reporting.Rpt_RSQC_CustInspecStatSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CustInspecStatSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CustInspecStatSSRS>(_Rpt_RSQC_CustInspecStatSSRS);
			
			return iRpt_RSQC_CustInspecStatSSRSExt;
		}
	}
}
