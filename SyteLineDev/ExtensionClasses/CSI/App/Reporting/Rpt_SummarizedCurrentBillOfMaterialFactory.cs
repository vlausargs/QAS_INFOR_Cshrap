//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SummarizedCurrentBillOfMaterialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SummarizedCurrentBillOfMaterialFactory
	{
		public IRpt_SummarizedCurrentBillOfMaterial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SummarizedCurrentBillOfMaterial = new Reporting.Rpt_SummarizedCurrentBillOfMaterial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SummarizedCurrentBillOfMaterialExt = timerfactory.Create<Reporting.IRpt_SummarizedCurrentBillOfMaterial>(_Rpt_SummarizedCurrentBillOfMaterial);
			
			return iRpt_SummarizedCurrentBillOfMaterialExt;
		}
	}
}
