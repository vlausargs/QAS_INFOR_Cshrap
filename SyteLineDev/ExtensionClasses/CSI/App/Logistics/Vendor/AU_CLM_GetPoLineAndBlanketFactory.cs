//PROJECT NAME: Logistics
//CLASS NAME: AU_CLM_GetPoLineAndBlanketFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class AU_CLM_GetPoLineAndBlanketFactory
	{
		public IAU_CLM_GetPoLineAndBlanket Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _AU_CLM_GetPoLineAndBlanket = new Logistics.Vendor.AU_CLM_GetPoLineAndBlanket(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CLM_GetPoLineAndBlanketExt = timerfactory.Create<Logistics.Vendor.IAU_CLM_GetPoLineAndBlanket>(_AU_CLM_GetPoLineAndBlanket);
			
			return iAU_CLM_GetPoLineAndBlanketExt;
		}
	}
}
