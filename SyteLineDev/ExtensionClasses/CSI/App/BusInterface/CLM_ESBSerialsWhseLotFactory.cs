//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSerialsWhseLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSerialsWhseLotFactory
	{
		public ICLM_ESBSerialsWhseLot Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSerialsWhseLot = new BusInterface.CLM_ESBSerialsWhseLot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSerialsWhseLotExt = timerfactory.Create<BusInterface.ICLM_ESBSerialsWhseLot>(_CLM_ESBSerialsWhseLot);
			
			return iCLM_ESBSerialsWhseLotExt;
		}
	}
}
