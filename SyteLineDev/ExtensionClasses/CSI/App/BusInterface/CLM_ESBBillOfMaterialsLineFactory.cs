//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBBillOfMaterialsLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBBillOfMaterialsLineFactory
	{
		public ICLM_ESBBillOfMaterialsLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBBillOfMaterialsLine = new BusInterface.CLM_ESBBillOfMaterialsLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBBillOfMaterialsLineExt = timerfactory.Create<BusInterface.ICLM_ESBBillOfMaterialsLine>(_CLM_ESBBillOfMaterialsLine);
			
			return iCLM_ESBBillOfMaterialsLineExt;
		}
	}
}
