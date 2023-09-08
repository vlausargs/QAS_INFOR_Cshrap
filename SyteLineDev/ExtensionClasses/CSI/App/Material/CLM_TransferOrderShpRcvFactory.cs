//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_TransferOrderShpRcvFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_TransferOrderShpRcvFactory
	{
		public ICLM_TransferOrderShpRcv Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_TransferOrderShpRcv = new Material.CLM_TransferOrderShpRcv(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TransferOrderShpRcvExt = timerfactory.Create<Material.ICLM_TransferOrderShpRcv>(_CLM_TransferOrderShpRcv);
			
			return iCLM_TransferOrderShpRcvExt;
		}
	}
}
