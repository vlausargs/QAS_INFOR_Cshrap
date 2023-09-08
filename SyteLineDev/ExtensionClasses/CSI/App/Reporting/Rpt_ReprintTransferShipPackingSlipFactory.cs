//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintTransferShipPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ReprintTransferShipPackingSlipFactory
	{
		public IRpt_ReprintTransferShipPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ReprintTransferShipPackingSlip = new Reporting.Rpt_ReprintTransferShipPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ReprintTransferShipPackingSlipExt = timerfactory.Create<Reporting.IRpt_ReprintTransferShipPackingSlip>(_Rpt_ReprintTransferShipPackingSlip);
			
			return iRpt_ReprintTransferShipPackingSlipExt;
		}
	}
}
