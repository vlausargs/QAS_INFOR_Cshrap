//PROJECT NAME: Finance
//CLASS NAME: MXVATARTransferFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance.Mexican
{
	public class MXVATARTransferFactory
	{
		public IMXVATARTransfer Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MXVATARTransfer = new Finance.Mexican.MXVATARTransfer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMXVATARTransferExt = timerfactory.Create<Finance.Mexican.IMXVATARTransfer>(_MXVATARTransfer);
			
			return iMXVATARTransferExt;
		}
	}
}
