//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_COCSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_COCSSRSFactory
	{
		public IRpt_RSQC_COCSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_COCSSRS = new Reporting.Rpt_RSQC_COCSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_COCSSRSExt = timerfactory.Create<Reporting.IRpt_RSQC_COCSSRS>(_Rpt_RSQC_COCSSRS);
			
			return iRpt_RSQC_COCSSRSExt;
		}
	}
}
