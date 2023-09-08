//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetCONSPLANSubGridFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetCONSPLANSubGridFactory
	{
		public ICLM_ApsGetCONSPLANSubGrid Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetCONSPLANSubGrid = new Production.APS.CLM_ApsGetCONSPLANSubGrid(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetCONSPLANSubGridExt = timerfactory.Create<Production.APS.ICLM_ApsGetCONSPLANSubGrid>(_CLM_ApsGetCONSPLANSubGrid);
			
			return iCLM_ApsGetCONSPLANSubGridExt;
		}
	}
}
