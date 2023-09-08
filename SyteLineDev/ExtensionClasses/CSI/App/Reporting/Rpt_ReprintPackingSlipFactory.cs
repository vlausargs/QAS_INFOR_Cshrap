//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ReprintPackingSlipFactory
	{
		public IRpt_ReprintPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ReprintPackingSlip = new Reporting.Rpt_ReprintPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ReprintPackingSlipExt = timerfactory.Create<Reporting.IRpt_ReprintPackingSlip>(_Rpt_ReprintPackingSlip);
			
			return iRpt_ReprintPackingSlipExt;
		}
	}
}
