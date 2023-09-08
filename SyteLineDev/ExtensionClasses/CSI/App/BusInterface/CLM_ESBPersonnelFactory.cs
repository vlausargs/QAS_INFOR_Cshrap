//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPersonnelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPersonnelFactory
	{
		public ICLM_ESBPersonnel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPersonnel = new BusInterface.CLM_ESBPersonnel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPersonnelExt = timerfactory.Create<BusInterface.ICLM_ESBPersonnel>(_CLM_ESBPersonnel);
			
			return iCLM_ESBPersonnelExt;
		}
	}
}
