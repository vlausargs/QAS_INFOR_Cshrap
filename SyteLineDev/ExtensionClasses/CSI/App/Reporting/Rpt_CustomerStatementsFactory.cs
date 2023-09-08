//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerStatementsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CustomerStatementsFactory
	{
		public IRpt_CustomerStatements Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerStatements = new Reporting.Rpt_CustomerStatements(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerStatementsExt = timerfactory.Create<Reporting.IRpt_CustomerStatements>(_Rpt_CustomerStatements);
			
			return iRpt_CustomerStatementsExt;
		}
	}
}
