//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TransferPackingSlipFactory
	{
		public IRpt_TransferPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TransferPackingSlip = new Reporting.Rpt_TransferPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TransferPackingSlipExt = timerfactory.Create<Reporting.IRpt_TransferPackingSlip>(_Rpt_TransferPackingSlip);
			
			return iRpt_TransferPackingSlipExt;
		}
	}
}
