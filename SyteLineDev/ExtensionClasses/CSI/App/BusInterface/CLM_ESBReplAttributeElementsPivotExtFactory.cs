//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReplAttributeElementsPivotExtFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReplAttributeElementsPivotExtFactory
	{
		public ICLM_ESBReplAttributeElementsPivotExt Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReplAttributeElementsPivotExt = new BusInterface.CLM_ESBReplAttributeElementsPivotExt(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReplAttributeElementsPivotExtExt = timerfactory.Create<BusInterface.ICLM_ESBReplAttributeElementsPivotExt>(_CLM_ESBReplAttributeElementsPivotExt);
			
			return iCLM_ESBReplAttributeElementsPivotExtExt;
		}
	}
}
