//PROJECT NAME: Material
//CLASS NAME: CLM_LoadBackflushFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_LoadBackflushFactory
	{
		public ICLM_LoadBackflush Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LoadBackflush = new Material.CLM_LoadBackflush(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LoadBackflushExt = timerfactory.Create<Material.ICLM_LoadBackflush>(_CLM_LoadBackflush);
			
			return iCLM_LoadBackflushExt;
		}
	}
}
