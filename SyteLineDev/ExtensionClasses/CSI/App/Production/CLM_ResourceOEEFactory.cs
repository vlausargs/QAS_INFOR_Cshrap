//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_ResourceOEEFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_ResourceOEEFactory
	{
		public ICLM_ResourceOEE Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ResourceOEE = new Production.CLM_ResourceOEE(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ResourceOEEExt = timerfactory.Create<Production.ICLM_ResourceOEE>(_CLM_ResourceOEE);
			
			return iCLM_ResourceOEEExt;
		}
	}
}
