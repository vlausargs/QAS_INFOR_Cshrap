//PROJECT NAME: Reporting
//CLASS NAME: THARpt_InputVATFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_InputVATFactory
	{
		public ITHARpt_InputVAT Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_InputVAT = new Reporting.THARpt_InputVAT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_InputVATExt = timerfactory.Create<Reporting.ITHARpt_InputVAT>(_THARpt_InputVAT);
			
			return iTHARpt_InputVATExt;
		}
	}
}
