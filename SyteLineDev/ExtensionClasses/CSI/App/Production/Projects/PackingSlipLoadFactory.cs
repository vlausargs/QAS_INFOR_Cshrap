//PROJECT NAME: Production
//CLASS NAME: PackingSlipLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.Projects
{
	public class PackingSlipLoadFactory
	{
		public IPackingSlipLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PackingSlipLoad = new Production.Projects.PackingSlipLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPackingSlipLoadExt = timerfactory.Create<Production.Projects.IPackingSlipLoad>(_PackingSlipLoad);
			
			return iPackingSlipLoadExt;
		}
	}
}
