//PROJECT NAME: Material
//CLASS NAME: CLM_ItemNotUsedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_ItemNotUsedFactory
	{
		public ICLM_ItemNotUsed Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ItemNotUsed = new Material.CLM_ItemNotUsed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ItemNotUsedExt = timerfactory.Create<Material.ICLM_ItemNotUsed>(_CLM_ItemNotUsed);
			
			return iCLM_ItemNotUsedExt;
		}
	}
}
