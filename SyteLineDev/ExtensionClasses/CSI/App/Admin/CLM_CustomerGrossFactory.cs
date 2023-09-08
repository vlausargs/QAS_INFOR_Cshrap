//PROJECT NAME: CSIAdmin
//CLASS NAME: CLM_CustomerGrossFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_CustomerGrossFactory
	{
		public ICLM_CustomerGross Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CustomerGross = new Admin.CLM_CustomerGross(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerGrossExt = timerfactory.Create<Admin.ICLM_CustomerGross>(_CLM_CustomerGross);
			
			return iCLM_CustomerGrossExt;
		}
	}
}
