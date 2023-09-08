//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_SPC2Factory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_RSQC_SPC2Factory
	{
		public IRPT_RSQC_SPC2 Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_RSQC_SPC2 = new Reporting.RPT_RSQC_SPC2(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_RSQC_SPC2Ext = timerfactory.Create<Reporting.IRPT_RSQC_SPC2>(_RPT_RSQC_SPC2);
			
			return iRPT_RSQC_SPC2Ext;
		}
	}
}
