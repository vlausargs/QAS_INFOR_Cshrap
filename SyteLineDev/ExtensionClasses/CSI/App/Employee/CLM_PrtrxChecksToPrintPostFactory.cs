//PROJECT NAME: CSIEmployee
//CLASS NAME: CLM_PrtrxChecksToPrintPostFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_PrtrxChecksToPrintPostFactory
	{
		public ICLM_PrtrxChecksToPrintPost Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PrtrxChecksToPrintPost = new Employee.CLM_PrtrxChecksToPrintPost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PrtrxChecksToPrintPostExt = timerfactory.Create<Employee.ICLM_PrtrxChecksToPrintPost>(_CLM_PrtrxChecksToPrintPost);
			
			return iCLM_PrtrxChecksToPrintPostExt;
		}
	}
}
