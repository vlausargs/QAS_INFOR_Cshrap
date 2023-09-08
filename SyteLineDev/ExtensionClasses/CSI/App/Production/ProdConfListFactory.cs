//PROJECT NAME: Production
//CLASS NAME: ProdConfListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class ProdConfListFactory
	{
		public IProdConfList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProdConfList = new Production.ProdConfList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProdConfListExt = timerfactory.Create<Production.IProdConfList>(_ProdConfList);
			
			return iProdConfListExt;
		}
	}
}
