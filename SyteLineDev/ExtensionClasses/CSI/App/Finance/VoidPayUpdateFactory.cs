//PROJECT NAME: Finance
//CLASS NAME: VoidPayUpdateFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class VoidPayUpdateFactory
	{
		public IVoidPayUpdate Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VoidPayUpdate = new Finance.VoidPayUpdate(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidPayUpdateExt = timerfactory.Create<Finance.IVoidPayUpdate>(_VoidPayUpdate);
			
			return iVoidPayUpdateExt;
		}
	}
}
