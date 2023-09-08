//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchasedComponentsCrossReferenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchasedComponentsCrossReferenceFactory
	{
		public IRpt_PurchasedComponentsCrossReference Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchasedComponentsCrossReference = new Reporting.Rpt_PurchasedComponentsCrossReference(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchasedComponentsCrossReferenceExt = timerfactory.Create<Reporting.IRpt_PurchasedComponentsCrossReference>(_Rpt_PurchasedComponentsCrossReference);
			
			return iRpt_PurchasedComponentsCrossReferenceExt;
		}
	}
}
