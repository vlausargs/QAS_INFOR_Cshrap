//PROJECT NAME: Production
//CLASS NAME: PrjTshpBuildFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class PrjTshpBuildFactory
	{
		public IPrjTshpBuild Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PrjTshpBuild = new Production.Projects.PrjTshpBuild(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrjTshpBuildExt = timerfactory.Create<Production.Projects.IPrjTshpBuild>(_PrjTshpBuild);
			
			return iPrjTshpBuildExt;
		}
	}
}
