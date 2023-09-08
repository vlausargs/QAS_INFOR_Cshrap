//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_PartnerScheduleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_PartnerScheduleFactory
	{
		public ISSSFSRpt_PartnerSchedule Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_PartnerSchedule = new Reporting.SSSFSRpt_PartnerSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_PartnerScheduleExt = timerfactory.Create<Reporting.ISSSFSRpt_PartnerSchedule>(_SSSFSRpt_PartnerSchedule);
			
			return iSSSFSRpt_PartnerScheduleExt;
		}
	}
}
