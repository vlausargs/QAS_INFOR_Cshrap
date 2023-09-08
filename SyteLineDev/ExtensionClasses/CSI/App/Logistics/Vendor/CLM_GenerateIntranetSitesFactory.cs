//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateIntranetSitesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_GenerateIntranetSitesFactory
	{
		public ICLM_GenerateIntranetSites Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GenerateIntranetSites = new Logistics.Vendor.CLM_GenerateIntranetSites(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GenerateIntranetSitesExt = timerfactory.Create<Logistics.Vendor.ICLM_GenerateIntranetSites>(_CLM_GenerateIntranetSites);
			
			return iCLM_GenerateIntranetSitesExt;
		}
	}
}
