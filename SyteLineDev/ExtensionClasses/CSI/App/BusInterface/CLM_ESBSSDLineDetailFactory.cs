//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSSDLineDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSSDLineDetailFactory
	{
		public ICLM_ESBSSDLineDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSSDLineDetail = new BusInterface.CLM_ESBSSDLineDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSSDLineDetailExt = timerfactory.Create<BusInterface.ICLM_ESBSSDLineDetail>(_CLM_ESBSSDLineDetail);
			
			return iCLM_ESBSSDLineDetailExt;
		}
	}
}
