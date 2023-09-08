//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSHIFTEXDIFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSHIFTEXDIFactory
	{
		public ICLM_ApsGetSHIFTEXDI Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSHIFTEXDI = new Production.APS.CLM_ApsGetSHIFTEXDI(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSHIFTEXDIExt = timerfactory.Create<Production.APS.ICLM_ApsGetSHIFTEXDI>(_CLM_ApsGetSHIFTEXDI);
			
			return iCLM_ApsGetSHIFTEXDIExt;
		}
	}
}
