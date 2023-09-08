//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBItemMasterHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBItemMasterHeaderFactory
	{
		public ICLM_ESBItemMasterHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBItemMasterHeader = new BusInterface.CLM_ESBItemMasterHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBItemMasterHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBItemMasterHeader>(_CLM_ESBItemMasterHeader);
			
			return iCLM_ESBItemMasterHeaderExt;
		}
	}
}
