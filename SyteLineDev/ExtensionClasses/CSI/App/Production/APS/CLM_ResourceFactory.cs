//PROJECT NAME: Production
//CLASS NAME: CLM_ResourceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ResourceFactory
	{
		public ICLM_Resource Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_Resource = new Production.APS.CLM_Resource(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ResourceExt = timerfactory.Create<Production.APS.ICLM_Resource>(_CLM_Resource);
			
			return iCLM_ResourceExt;
		}
	}
}
