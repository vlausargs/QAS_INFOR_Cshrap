//PROJECT NAME: Material
//CLASS NAME: CLM_ManufacturerItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_ManufacturerItemFactory
	{
		public ICLM_ManufacturerItem Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ManufacturerItem = new Material.CLM_ManufacturerItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ManufacturerItemExt = timerfactory.Create<Material.ICLM_ManufacturerItem>(_CLM_ManufacturerItem);
			
			return iCLM_ManufacturerItemExt;
		}
	}
}
