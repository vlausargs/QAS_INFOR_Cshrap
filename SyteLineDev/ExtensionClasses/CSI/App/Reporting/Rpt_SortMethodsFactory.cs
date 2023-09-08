//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SortMethodsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SortMethodsFactory
	{
		public IRpt_SortMethods Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SortMethods = new Reporting.Rpt_SortMethods(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SortMethodsExt = timerfactory.Create<Reporting.IRpt_SortMethods>(_Rpt_SortMethods);
			
			return iRpt_SortMethodsExt;
		}
	}
}
