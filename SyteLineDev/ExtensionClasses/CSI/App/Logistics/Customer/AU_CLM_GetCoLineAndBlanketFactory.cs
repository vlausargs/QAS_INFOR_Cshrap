//PROJECT NAME: Logistics
//CLASS NAME: AU_CLM_GetCoLineAndBlanketFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class AU_CLM_GetCoLineAndBlanketFactory
	{
		public IAU_CLM_GetCoLineAndBlanket Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AU_CLM_GetCoLineAndBlanket = new Logistics.Customer.AU_CLM_GetCoLineAndBlanket(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CLM_GetCoLineAndBlanketExt = timerfactory.Create<Logistics.Customer.IAU_CLM_GetCoLineAndBlanket>(_AU_CLM_GetCoLineAndBlanket);
			
			return iAU_CLM_GetCoLineAndBlanketExt;
		}
	}
}
