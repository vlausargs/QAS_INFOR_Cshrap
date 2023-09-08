//PROJECT NAME: Admin
//CLASS NAME: ProspectInteractionCalendarFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class ProspectInteractionCalendarFactory
	{
		public IProspectInteractionCalendar Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProspectInteractionCalendar = new Admin.ProspectInteractionCalendar(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProspectInteractionCalendarExt = timerfactory.Create<Admin.IProspectInteractionCalendar>(_ProspectInteractionCalendar);
			
			return iProspectInteractionCalendarExt;
		}
	}
}
