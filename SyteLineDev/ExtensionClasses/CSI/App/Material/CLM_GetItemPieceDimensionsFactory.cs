//PROJECT NAME: Material
//CLASS NAME: CLM_GetItemPieceDimensionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_GetItemPieceDimensionsFactory
	{
		public ICLM_GetItemPieceDimensions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetItemPieceDimensions = new Material.CLM_GetItemPieceDimensions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetItemPieceDimensionsExt = timerfactory.Create<Material.ICLM_GetItemPieceDimensions>(_CLM_GetItemPieceDimensions);
			
			return iCLM_GetItemPieceDimensionsExt;
		}
	}
}
