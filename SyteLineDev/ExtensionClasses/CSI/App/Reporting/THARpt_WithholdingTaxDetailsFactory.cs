//PROJECT NAME: Reporting
//CLASS NAME: THARpt_WithholdingTaxDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_WithholdingTaxDetailsFactory
	{
		public ITHARpt_WithholdingTaxDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_WithholdingTaxDetails = new Reporting.THARpt_WithholdingTaxDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_WithholdingTaxDetailsExt = timerfactory.Create<Reporting.ITHARpt_WithholdingTaxDetails>(_THARpt_WithholdingTaxDetails);
			
			return iTHARpt_WithholdingTaxDetailsExt;
		}
	}
}
