//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RMAStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RMAStatusFactory
	{
		public IRpt_RMAStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RMAStatus = new Reporting.Rpt_RMAStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RMAStatusExt = timerfactory.Create<Reporting.IRpt_RMAStatus>(_Rpt_RMAStatus);
			
			return iRpt_RMAStatusExt;
		}
	}
}
