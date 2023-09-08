//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectPackingSlipFactory
	{
		public IRpt_ProjectPackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectPackingSlip = new Reporting.Rpt_ProjectPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectPackingSlipExt = timerfactory.Create<Reporting.IRpt_ProjectPackingSlip>(_Rpt_ProjectPackingSlip);
			
			return iRpt_ProjectPackingSlipExt;
		}
	}
}
