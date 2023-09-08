//PROJECT NAME: Material
//CLASS NAME: GetJobmatlTranLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class GetJobmatlTranLotFactory
	{
		public IGetJobmatlTranLot Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetJobmatlTranLot = new Material.GetJobmatlTranLot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetJobmatlTranLotExt = timerfactory.Create<Material.IGetJobmatlTranLot>(_GetJobmatlTranLot);
			
			return iGetJobmatlTranLotExt;
		}
	}
}
