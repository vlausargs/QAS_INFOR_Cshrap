//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_SPCSSRSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_SPCSSRSFactory
	{
		public IRPT_RSQC_SPCSSRS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_SPCSSRS = new Reporting.RPT_RSQC_SPCSSRS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_SPCSSRSExt = timerfactory.Create<Reporting.IRPT_RSQC_SPCSSRS>(_RPT_RSQC_SPCSSRS);
			
			return iRPT_RSQC_SPCSSRSExt;
		}
	}
}
