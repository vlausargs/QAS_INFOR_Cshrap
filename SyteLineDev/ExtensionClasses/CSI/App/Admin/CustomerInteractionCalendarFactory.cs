//PROJECT NAME: Admin
//CLASS NAME: CustomerInteractionCalendarFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CustomerInteractionCalendarFactory
	{
		public ICustomerInteractionCalendar Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CustomerInteractionCalendar = new Admin.CustomerInteractionCalendar(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerInteractionCalendarExt = timerfactory.Create<Admin.ICustomerInteractionCalendar>(_CustomerInteractionCalendar);
			
			return iCustomerInteractionCalendarExt;
		}
	}
}
