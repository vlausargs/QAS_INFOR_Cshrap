//PROJECT NAME: Material
//CLASS NAME: CLM_RMAReturnSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_RMAReturnSerialLoadFactory
	{
		public ICLM_RMAReturnSerialLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_RMAReturnSerialLoad = new Material.CLM_RMAReturnSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_RMAReturnSerialLoadExt = timerfactory.Create<Material.ICLM_RMAReturnSerialLoad>(_CLM_RMAReturnSerialLoad);
			
			return iCLM_RMAReturnSerialLoadExt;
		}
	}
}
