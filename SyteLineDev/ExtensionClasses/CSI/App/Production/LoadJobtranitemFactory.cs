//PROJECT NAME: Production
//CLASS NAME: LoadJobtranitemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class LoadJobtranitemFactory
	{
		public ILoadJobtranitem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _LoadJobtranitem = new Production.LoadJobtranitem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadJobtranitemExt = timerfactory.Create<Production.ILoadJobtranitem>(_LoadJobtranitem);
			
			return iLoadJobtranitemExt;
		}
	}
}
