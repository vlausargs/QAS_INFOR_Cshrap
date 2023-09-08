//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectPackingSlipFactory
	{
		public IRpt_ReprintProjectPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ReprintProjectPackingSlip = new Reporting.Rpt_ReprintProjectPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ReprintProjectPackingSlipExt = timerfactory.Create<Reporting.IRpt_ReprintProjectPackingSlip>(_Rpt_ReprintProjectPackingSlip);
			
			return iRpt_ReprintProjectPackingSlipExt;
		}
	}
}
