//PROJECT NAME: Logistics
//CLASS NAME: FTSLTeamMemberReportingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLTeamMemberReportingFactory
	{
		public IFTSLTeamMemberReporting Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLTeamMemberReporting = new Logistics.WarehouseMobility.FTSLTeamMemberReporting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLTeamMemberReportingExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLTeamMemberReporting>(_FTSLTeamMemberReporting);
			
			return iFTSLTeamMemberReportingExt;
		}
	}
}
