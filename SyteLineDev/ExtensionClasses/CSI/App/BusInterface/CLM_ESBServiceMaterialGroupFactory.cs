//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBServiceMaterialGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBServiceMaterialGroupFactory
	{
		public ICLM_ESBServiceMaterialGroup Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBServiceMaterialGroup = new BusInterface.CLM_ESBServiceMaterialGroup(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBServiceMaterialGroupExt = timerfactory.Create<BusInterface.ICLM_ESBServiceMaterialGroup>(_CLM_ESBServiceMaterialGroup);
			
			return iCLM_ESBServiceMaterialGroupExt;
		}
	}
}
