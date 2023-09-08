//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupDispatchListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupDispatchListFactory
	{
		public IRpt_ResourceGroupDispatchList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceGroupDispatchList = new Reporting.Rpt_ResourceGroupDispatchList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceGroupDispatchListExt = timerfactory.Create<Reporting.IRpt_ResourceGroupDispatchList>(_Rpt_ResourceGroupDispatchList);
			
			return iRpt_ResourceGroupDispatchListExt;
		}
	}
}
