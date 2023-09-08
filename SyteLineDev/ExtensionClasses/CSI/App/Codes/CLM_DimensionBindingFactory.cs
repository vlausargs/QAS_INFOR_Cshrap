//PROJECT NAME: Codes
//CLASS NAME: CLM_DimensionBindingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_DimensionBindingFactory
	{
		public ICLM_DimensionBinding Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DimensionBinding = new Codes.CLM_DimensionBinding(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DimensionBindingExt = timerfactory.Create<Codes.ICLM_DimensionBinding>(_CLM_DimensionBinding);
			
			return iCLM_DimensionBindingExt;
		}
	}
}
