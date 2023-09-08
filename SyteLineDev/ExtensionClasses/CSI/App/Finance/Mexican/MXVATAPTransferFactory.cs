//PROJECT NAME: Finance
//CLASS NAME: MXVATAPTransferFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance.Mexican
{
	public class MXVATAPTransferFactory
	{
		public IMXVATAPTransfer Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MXVATAPTransfer = new Finance.Mexican.MXVATAPTransfer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMXVATAPTransferExt = timerfactory.Create<Finance.Mexican.IMXVATAPTransfer>(_MXVATAPTransfer);
			
			return iMXVATAPTransferExt;
		}
	}
}
