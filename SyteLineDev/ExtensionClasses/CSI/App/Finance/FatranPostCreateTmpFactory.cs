//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostCreateTmpFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class FatranPostCreateTmpFactory
	{
		public IFatranPostCreateTmp Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FatranPostCreateTmp = new Finance.FatranPostCreateTmp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFatranPostCreateTmpExt = timerfactory.Create<Finance.IFatranPostCreateTmp>(_FatranPostCreateTmp);
			
			return iFatranPostCreateTmpExt;
		}
	}
}
