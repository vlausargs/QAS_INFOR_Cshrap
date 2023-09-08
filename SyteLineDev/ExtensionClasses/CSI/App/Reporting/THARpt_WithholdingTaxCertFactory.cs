//PROJECT NAME: Reporting
//CLASS NAME: THARpt_WithholdingTaxCertFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_WithholdingTaxCertFactory
	{
		public ITHARpt_WithholdingTaxCert Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_WithholdingTaxCert = new Reporting.THARpt_WithholdingTaxCert(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_WithholdingTaxCertExt = timerfactory.Create<Reporting.ITHARpt_WithholdingTaxCert>(_THARpt_WithholdingTaxCert);
			
			return iTHARpt_WithholdingTaxCertExt;
		}
	}
}
