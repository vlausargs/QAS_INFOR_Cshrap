//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobTravellerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobTravellerFactory
	{
		public IRpt_JobTraveller Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobTraveller = new Reporting.Rpt_JobTraveller(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobTravellerExt = timerfactory.Create<Reporting.IRpt_JobTraveller>(_Rpt_JobTraveller);
			
			return iRpt_JobTravellerExt;
		}
	}
}
