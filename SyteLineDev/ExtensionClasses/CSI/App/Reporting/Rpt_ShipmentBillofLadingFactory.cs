//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentBillofLadingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ShipmentBillofLadingFactory
	{
		public IRpt_ShipmentBillofLading Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ShipmentBillofLading = new Reporting.Rpt_ShipmentBillofLading(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ShipmentBillofLadingExt = timerfactory.Create<Reporting.IRpt_ShipmentBillofLading>(_Rpt_ShipmentBillofLading);
			
			return iRpt_ShipmentBillofLadingExt;
		}
	}
}
