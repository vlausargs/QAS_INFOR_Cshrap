//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MXVATARTransferredFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MXVATARTransferredFactory
	{
		public IRpt_MXVATARTransferred Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MXVATARTransferred = new Reporting.Rpt_MXVATARTransferred(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MXVATARTransferredExt = timerfactory.Create<Reporting.IRpt_MXVATARTransferred>(_Rpt_MXVATARTransferred);
			
			return iRpt_MXVATARTransferredExt;
		}
	}
}
