//PROJECT NAME: Material
//CLASS NAME: TrnPackingSlipLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class TrnPackingSlipLoadFactory
	{
		public ITrnPackingSlipLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TrnPackingSlipLoad = new Material.TrnPackingSlipLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnPackingSlipLoadExt = timerfactory.Create<Material.ITrnPackingSlipLoad>(_TrnPackingSlipLoad);
			
			return iTrnPackingSlipLoadExt;
		}
	}
}
