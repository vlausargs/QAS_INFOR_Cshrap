//PROJECT NAME: CSIPmf
//CLASS NAME: PmfRptSelectSessSpecFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptSelectSessSpecFactory
	{
		public IPmfRptSelectSessSpec Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfRptSelectSessSpec = new Production.ProcessManufacturing.PmfRptSelectSessSpec(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRptSelectSessSpecExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRptSelectSessSpec>(_PmfRptSelectSessSpec);
			
			return iPmfRptSelectSessSpecExt;
		}
	}
}
