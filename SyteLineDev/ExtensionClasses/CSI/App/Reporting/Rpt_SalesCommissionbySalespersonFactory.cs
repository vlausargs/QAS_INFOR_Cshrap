//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesCommissionbySalespersonFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SalesCommissionbySalespersonFactory
	{
		public IRpt_SalesCommissionbySalesperson Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalesCommissionbySalesperson = new Reporting.Rpt_SalesCommissionbySalesperson(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalesCommissionbySalespersonExt = timerfactory.Create<Reporting.IRpt_SalesCommissionbySalesperson>(_Rpt_SalesCommissionbySalesperson);
			
			return iRpt_SalesCommissionbySalespersonExt;
		}
	}
}
