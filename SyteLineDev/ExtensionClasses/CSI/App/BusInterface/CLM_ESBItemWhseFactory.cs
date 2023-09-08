//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBItemWhseFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBItemWhseFactory
	{
		public ICLM_ESBItemWhse Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBItemWhse = new BusInterface.CLM_ESBItemWhse(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBItemWhseExt = timerfactory.Create<BusInterface.ICLM_ESBItemWhse>(_CLM_ESBItemWhse);
			
			return iCLM_ESBItemWhseExt;
		}
	}
}
