//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseRequirementsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchaseRequirementsFactory
	{
		public IRpt_PurchaseRequirements Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchaseRequirements = new Reporting.Rpt_PurchaseRequirements(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchaseRequirementsExt = timerfactory.Create<Reporting.IRpt_PurchaseRequirements>(_Rpt_PurchaseRequirements);
			
			return iRpt_PurchaseRequirementsExt;
		}
	}
}
