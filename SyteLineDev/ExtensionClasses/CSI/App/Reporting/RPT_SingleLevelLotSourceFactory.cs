//PROJECT NAME: Reporting
//CLASS NAME: RPT_SingleLevelLotSourceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_SingleLevelLotSourceFactory
	{
		public IRPT_SingleLevelLotSource Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_SingleLevelLotSource = new Reporting.RPT_SingleLevelLotSource(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_SingleLevelLotSourceExt = timerfactory.Create<Reporting.IRPT_SingleLevelLotSource>(_RPT_SingleLevelLotSource);
			
			return iRPT_SingleLevelLotSourceExt;
		}
	}
}
