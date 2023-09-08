//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBBillOfMaterialsHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBBillOfMaterialsHeaderFactory
	{
		public ICLM_ESBBillOfMaterialsHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBBillOfMaterialsHeader = new BusInterface.CLM_ESBBillOfMaterialsHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBBillOfMaterialsHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBBillOfMaterialsHeader>(_CLM_ESBBillOfMaterialsHeader);
			
			return iCLM_ESBBillOfMaterialsHeaderExt;
		}
	}
}
