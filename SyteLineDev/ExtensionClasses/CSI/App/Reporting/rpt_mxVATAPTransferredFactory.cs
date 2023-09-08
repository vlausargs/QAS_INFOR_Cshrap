//PROJECT NAME: Reporting
//CLASS NAME: rpt_mxVATAPTransferredFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class rpt_mxVATAPTransferredFactory
	{
		public Irpt_mxVATAPTransferred Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _rpt_mxVATAPTransferred = new Reporting.rpt_mxVATAPTransferred(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var irpt_mxVATAPTransferredExt = timerfactory.Create<Reporting.Irpt_mxVATAPTransferred>(_rpt_mxVATAPTransferred);
			
			return irpt_mxVATAPTransferredExt;
		}
	}
}
