//PROJECT NAME: Reporting
//CLASS NAME: THARpt_WithholdingTaxCertificateFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_WithholdingTaxCertificateFactory
	{
		public ITHARpt_WithholdingTaxCertificate Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_WithholdingTaxCertificate = new Reporting.THARpt_WithholdingTaxCertificate(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_WithholdingTaxCertificateExt = timerfactory.Create<Reporting.ITHARpt_WithholdingTaxCertificate>(_THARpt_WithholdingTaxCertificate);
			
			return iTHARpt_WithholdingTaxCertificateExt;
		}
	}
}
