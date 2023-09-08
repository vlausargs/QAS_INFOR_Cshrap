//PROJECT NAME: Production
//CLASS NAME: ProjPckHdrsLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProjPckHdrsLoadFactory
	{
		public IProjPckHdrsLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProjPckHdrsLoad = new Production.Projects.ProjPckHdrsLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjPckHdrsLoadExt = timerfactory.Create<Production.Projects.IProjPckHdrsLoad>(_ProjPckHdrsLoad);
			
			return iProjPckHdrsLoadExt;
		}
	}
}
