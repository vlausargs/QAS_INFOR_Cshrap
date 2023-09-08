//PROJECT NAME: Production
//CLASS NAME: CLM_ItemBottlenecksDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ItemBottlenecksDetailsFactory
	{
		public ICLM_ItemBottlenecksDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ItemBottlenecksDetails = new Production.APS.CLM_ItemBottlenecksDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ItemBottlenecksDetailsExt = timerfactory.Create<Production.APS.ICLM_ItemBottlenecksDetails>(_CLM_ItemBottlenecksDetails);
			
			return iCLM_ItemBottlenecksDetailsExt;
		}
	}
}
