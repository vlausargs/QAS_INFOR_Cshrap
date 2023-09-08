//PROJECT NAME: Production
//CLASS NAME: LoadJobtranitemCoProductFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class LoadJobtranitemCoProductFactory
	{
		public ILoadJobtranitemCoProduct Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _LoadJobtranitemCoProduct = new Production.LoadJobtranitemCoProduct(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadJobtranitemCoProductExt = timerfactory.Create<Production.ILoadJobtranitemCoProduct>(_LoadJobtranitemCoProduct);
			
			return iLoadJobtranitemCoProductExt;
		}
	}
}
