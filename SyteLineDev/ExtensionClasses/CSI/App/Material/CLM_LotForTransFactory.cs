//PROJECT NAME: Material
//CLASS NAME: CLM_LotForTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_LotForTransFactory
	{
		public ICLM_LotForTrans Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_LotForTrans = new Material.CLM_LotForTrans(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_LotForTransExt = timerfactory.Create<Material.ICLM_LotForTrans>(_CLM_LotForTrans);
			
			return iCLM_LotForTransExt;
		}
	}
}
