//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TotalInventoryValuebyAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TotalInventoryValuebyAcctFactory
	{
		public IRpt_TotalInventoryValuebyAcct Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TotalInventoryValuebyAcct = new Reporting.Rpt_TotalInventoryValuebyAcct(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TotalInventoryValuebyAcctExt = timerfactory.Create<Reporting.IRpt_TotalInventoryValuebyAcct>(_Rpt_TotalInventoryValuebyAcct);
			
			return iRpt_TotalInventoryValuebyAcctExt;
		}
	}
}
