//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShippedNotApprovedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ShippedNotApprovedFactory
	{
		public IRpt_ShippedNotApproved Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ShippedNotApproved = new Reporting.Rpt_ShippedNotApproved(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ShippedNotApprovedExt = timerfactory.Create<Reporting.IRpt_ShippedNotApproved>(_Rpt_ShippedNotApproved);
			
			return iRpt_ShippedNotApprovedExt;
		}
	}
}
