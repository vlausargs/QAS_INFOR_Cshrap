//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetBATPRODORDFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetBATPRODORDFactory
	{
		public ICLM_ApsGetBATPRODORD Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetBATPRODORD = new Production.APS.CLM_ApsGetBATPRODORD(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetBATPRODORDExt = timerfactory.Create<Production.APS.ICLM_ApsGetBATPRODORD>(_CLM_ApsGetBATPRODORD);

			return iCLM_ApsGetBATPRODORDExt;
		}
	}
}
