//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSHIFTIntFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSHIFTIntFactory
	{
		public ICLM_ApsGetSHIFTInt Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSHIFTInt = new Production.APS.CLM_ApsGetSHIFTInt(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSHIFTIntExt = timerfactory.Create<Production.APS.ICLM_ApsGetSHIFTInt>(_CLM_ApsGetSHIFTInt);
			
			return iCLM_ApsGetSHIFTIntExt;
		}
	}
}
