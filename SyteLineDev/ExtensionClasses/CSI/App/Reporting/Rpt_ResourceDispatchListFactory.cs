//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceDispatchListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceDispatchListFactory
	{
		public IRpt_ResourceDispatchList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceDispatchList = new Reporting.Rpt_ResourceDispatchList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceDispatchListExt = timerfactory.Create<Reporting.IRpt_ResourceDispatchList>(_Rpt_ResourceDispatchList);
			
			return iRpt_ResourceDispatchListExt;
		}
	}
}
