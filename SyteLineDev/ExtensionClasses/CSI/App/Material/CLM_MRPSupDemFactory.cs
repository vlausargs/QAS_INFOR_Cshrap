//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_MRPSupDemFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_MRPSupDemFactory
	{
		public ICLM_MRPSupDem Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_MRPSupDem = new Material.CLM_MRPSupDem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_MRPSupDemExt = timerfactory.Create<Material.ICLM_MRPSupDem>(_CLM_MRPSupDem);
			
			return iCLM_MRPSupDemExt;
		}
	}
}
