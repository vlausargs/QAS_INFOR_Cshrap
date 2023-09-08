//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BarcodedResourcesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_BarcodedResourcesFactory
	{
		public IRpt_BarcodedResources Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_BarcodedResources = new Reporting.Rpt_BarcodedResources(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_BarcodedResourcesExt = timerfactory.Create<Reporting.IRpt_BarcodedResources>(_Rpt_BarcodedResources);
			
			return iRpt_BarcodedResourcesExt;
		}
	}
}
