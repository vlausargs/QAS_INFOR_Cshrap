//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ECSupplimentaryStatisticalDeclarationFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_ECSupplimentaryStatisticalDeclarationFactory
	{
		public ICLM_ECSupplimentaryStatisticalDeclaration Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ECSupplimentaryStatisticalDeclaration = new Logistics.Customer.CLM_ECSupplimentaryStatisticalDeclaration(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ECSupplimentaryStatisticalDeclarationExt = timerfactory.Create<Logistics.Customer.ICLM_ECSupplimentaryStatisticalDeclaration>(_CLM_ECSupplimentaryStatisticalDeclaration);
			
			return iCLM_ECSupplimentaryStatisticalDeclarationExt;
		}
	}
}
