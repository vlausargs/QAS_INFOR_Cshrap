//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CMRStatusSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CMRStatusSSRSFactory
	{
		public IRpt_RSQC_CMRStatusSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_CMRStatusSSRS = new Reporting.Rpt_RSQC_CMRStatusSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_CMRStatusSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_CMRStatusSSRS>(_Rpt_RSQC_CMRStatusSSRS);
			
			return iRpt_RSQC_CMRStatusSSRSExt;
		}
	}
}
