//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PORequisitionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PORequisitionFactory
	{
		public IRpt_PORequisition Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PORequisition = new Reporting.Rpt_PORequisition(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PORequisitionExt = timerfactory.Create<Reporting.IRpt_PORequisition>(_Rpt_PORequisition);
			
			return iRpt_PORequisitionExt;
		}
	}
}
