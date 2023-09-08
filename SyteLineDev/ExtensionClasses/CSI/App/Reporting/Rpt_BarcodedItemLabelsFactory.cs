//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BarcodedItemLabelsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_BarcodedItemLabelsFactory
	{
		public IRpt_BarcodedItemLabels Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_BarcodedItemLabels = new Reporting.Rpt_BarcodedItemLabels(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_BarcodedItemLabelsExt = timerfactory.Create<Reporting.IRpt_BarcodedItemLabels>(_Rpt_BarcodedItemLabels);
			
			return iRpt_BarcodedItemLabelsExt;
		}
	}
}
