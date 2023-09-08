//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintPackingSlipSerialNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ReprintPackingSlipSerialNumberFactory
	{
		public IRpt_ReprintPackingSlipSerialNumber Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ReprintPackingSlipSerialNumber = new Reporting.Rpt_ReprintPackingSlipSerialNumber(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ReprintPackingSlipSerialNumberExt = timerfactory.Create<Reporting.IRpt_ReprintPackingSlipSerialNumber>(_Rpt_ReprintPackingSlipSerialNumber);
			
			return iRpt_ReprintPackingSlipSerialNumberExt;
		}
	}
}
