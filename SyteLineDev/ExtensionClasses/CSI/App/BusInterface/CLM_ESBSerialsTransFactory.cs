//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSerialsTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSerialsTransFactory
	{
		public ICLM_ESBSerialsTrans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSerialsTrans = new BusInterface.CLM_ESBSerialsTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSerialsTransExt = timerfactory.Create<BusInterface.ICLM_ESBSerialsTrans>(_CLM_ESBSerialsTrans);
			
			return iCLM_ESBSerialsTransExt;
		}
	}
}
