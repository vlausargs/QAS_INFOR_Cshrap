//PROJECT NAME: Production
//CLASS NAME: ProjPckHdrsDeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class ProjPckHdrsDeleteFactory
	{
		public IProjPckHdrsDelete Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProjPckHdrsDelete = new Production.Projects.ProjPckHdrsDelete(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjPckHdrsDeleteExt = timerfactory.Create<Production.Projects.IProjPckHdrsDelete>(_ProjPckHdrsDelete);
			
			return iProjPckHdrsDeleteExt;
		}
	}
}
