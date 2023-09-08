//PROJECT NAME: CSIProduct
//CLASS NAME: DJobTranFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class DJobTranFactory
	{
		public IDJobTran Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DJobTran = new Production.DJobTran(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDJobTranExt = timerfactory.Create<Production.IDJobTran>(_DJobTran);
			
			return iDJobTranExt;
		}
	}
}
