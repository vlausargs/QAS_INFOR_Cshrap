//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemPriceChangeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemPriceChangeFactory
	{
		public IRpt_ItemPriceChange Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemPriceChange = new Reporting.Rpt_ItemPriceChange(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemPriceChangeExt = timerfactory.Create<Reporting.IRpt_ItemPriceChange>(_Rpt_ItemPriceChange);
			
			return iRpt_ItemPriceChangeExt;
		}
	}
}
