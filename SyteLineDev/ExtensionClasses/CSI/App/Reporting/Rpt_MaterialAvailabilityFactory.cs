//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MaterialAvailabilityFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MaterialAvailabilityFactory
	{
		public IRpt_MaterialAvailability Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MaterialAvailability = new Reporting.Rpt_MaterialAvailability(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MaterialAvailabilityExt = timerfactory.Create<Reporting.IRpt_MaterialAvailability>(_Rpt_MaterialAvailability);
			
			return iRpt_MaterialAvailabilityExt;
		}
	}
}
