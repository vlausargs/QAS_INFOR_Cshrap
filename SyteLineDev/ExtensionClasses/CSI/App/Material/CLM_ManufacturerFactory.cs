//PROJECT NAME: Material
//CLASS NAME: CLM_ManufacturerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_ManufacturerFactory
	{
		public ICLM_Manufacturer Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_Manufacturer = new Material.CLM_Manufacturer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ManufacturerExt = timerfactory.Create<Material.ICLM_Manufacturer>(_CLM_Manufacturer);
			
			return iCLM_ManufacturerExt;
		}
	}
}
