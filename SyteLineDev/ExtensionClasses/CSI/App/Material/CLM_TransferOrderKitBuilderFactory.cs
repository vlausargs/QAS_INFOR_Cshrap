//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_TransferOrderKitBuilderFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_TransferOrderKitBuilderFactory
	{
		public ICLM_TransferOrderKitBuilder Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_TransferOrderKitBuilder = new Material.CLM_TransferOrderKitBuilder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TransferOrderKitBuilderExt = timerfactory.Create<Material.ICLM_TransferOrderKitBuilder>(_CLM_TransferOrderKitBuilder);
			
			return iCLM_TransferOrderKitBuilderExt;
		}
	}
}
