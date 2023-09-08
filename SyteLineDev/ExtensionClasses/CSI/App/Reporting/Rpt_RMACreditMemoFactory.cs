//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RMACreditMemoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RMACreditMemoFactory
	{
		public IRpt_RMACreditMemo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RMACreditMemo = new Reporting.Rpt_RMACreditMemo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RMACreditMemoExt = timerfactory.Create<Reporting.IRpt_RMACreditMemo>(_Rpt_RMACreditMemo);
			
			return iRpt_RMACreditMemoExt;
		}
	}
}
