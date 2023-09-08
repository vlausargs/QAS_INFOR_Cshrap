//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupBottlenecksApsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupBottlenecksApsFactory
	{
		public IRpt_ResourceGroupBottlenecksAps Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceGroupBottlenecksAps = new Reporting.Rpt_ResourceGroupBottlenecksAps(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceGroupBottlenecksApsExt = timerfactory.Create<Reporting.IRpt_ResourceGroupBottlenecksAps>(_Rpt_ResourceGroupBottlenecksAps);
			
			return iRpt_ResourceGroupBottlenecksApsExt;
		}
	}
}
