//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBEUSalesLineDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBEUSalesLineDetailFactory
	{
		public ICLM_ESBEUSalesLineDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBEUSalesLineDetail = new BusInterface.CLM_ESBEUSalesLineDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBEUSalesLineDetailExt = timerfactory.Create<BusInterface.ICLM_ESBEUSalesLineDetail>(_CLM_ESBEUSalesLineDetail);
			
			return iCLM_ESBEUSalesLineDetailExt;
		}
	}
}
