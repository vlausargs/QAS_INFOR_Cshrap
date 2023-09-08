//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ShipmentPackingSlipFactory
	{
		public IRpt_ShipmentPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ShipmentPackingSlip = new Reporting.Rpt_ShipmentPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ShipmentPackingSlipExt = timerfactory.Create<Reporting.IRpt_ShipmentPackingSlip>(_Rpt_ShipmentPackingSlip);
			
			return iRpt_ShipmentPackingSlipExt;
		}
	}
}
