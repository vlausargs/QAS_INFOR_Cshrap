//PROJECT NAME: Admin
//CLASS NAME: GetTableStatisticsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class GetTableStatisticsFactory
	{
		public IGetTableStatistics Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetTableStatistics = new Admin.GetTableStatistics(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetTableStatisticsExt = timerfactory.Create<Admin.IGetTableStatistics>(_GetTableStatistics);
			
			return iGetTableStatisticsExt;
		}
	}
}
