//PROJECT NAME: CSIMaterial
//CLASS NAME: ProfileProFormaInvoiceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ProfileProFormaInvoiceFactory
	{
		public IProfileProFormaInvoice Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileProFormaInvoice = new Material.ProfileProFormaInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileProFormaInvoiceExt = timerfactory.Create<Material.IProfileProFormaInvoice>(_ProfileProFormaInvoice);
			
			return iProfileProFormaInvoiceExt;
		}
	}
}
