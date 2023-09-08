//PROJECT NAME: Admin
//CLASS NAME: OpportunityTaskCalendarFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class OpportunityTaskCalendarFactory
	{
		public IOpportunityTaskCalendar Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _OpportunityTaskCalendar = new Admin.OpportunityTaskCalendar(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iOpportunityTaskCalendarExt = timerfactory.Create<Admin.IOpportunityTaskCalendar>(_OpportunityTaskCalendar);
			
			return iOpportunityTaskCalendarExt;
		}
	}
}
