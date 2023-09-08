//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBItemWhseWhseFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBItemWhseWhseFactory
	{
		public ICLM_ESBItemWhseWhse Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBItemWhseWhse = new BusInterface.CLM_ESBItemWhseWhse(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBItemWhseWhseExt = timerfactory.Create<BusInterface.ICLM_ESBItemWhseWhse>(_CLM_ESBItemWhseWhse);
			
			return iCLM_ESBItemWhseWhseExt;
		}
	}
}
