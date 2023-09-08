//PROJECT NAME: Material
//CLASS NAME: CLM_EmptyStockroomLocsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_EmptyStockroomLocsFactory
	{
		public ICLM_EmptyStockroomLocs Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_EmptyStockroomLocs = new Material.CLM_EmptyStockroomLocs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_EmptyStockroomLocsExt = timerfactory.Create<Material.ICLM_EmptyStockroomLocs>(_CLM_EmptyStockroomLocs);
			
			return iCLM_EmptyStockroomLocsExt;
		}
	}
}
