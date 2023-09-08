//PROJECT NAME: Production
//CLASS NAME: ProjPercentCompleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProjPercentCompleteFactory
	{
		public IProjPercentComplete Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProjPercentComplete = new Production.Projects.ProjPercentComplete(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjPercentCompleteExt = timerfactory.Create<Production.Projects.IProjPercentComplete>(_ProjPercentComplete);
			
			return iProjPercentCompleteExt;
		}
	}
}
