//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInvItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInvItemFactory
	{
		public ICLM_ESBInvItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInvItem = new BusInterface.CLM_ESBInvItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInvItemExt = timerfactory.Create<BusInterface.ICLM_ESBInvItem>(_CLM_ESBInvItem);
			
			return iCLM_ESBInvItemExt;
		}
	}
}
