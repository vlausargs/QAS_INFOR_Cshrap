//PROJECT NAME: Material
//CLASS NAME: CLM_TranferLineDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_TranferLineDetailFactory
	{
		public ICLM_TranferLineDetail Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_TranferLineDetail = new Material.CLM_TranferLineDetail(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TranferLineDetailExt = timerfactory.Create<Material.ICLM_TranferLineDetail>(_CLM_TranferLineDetail);
			
			return iCLM_TranferLineDetailExt;
		}
	}
}
