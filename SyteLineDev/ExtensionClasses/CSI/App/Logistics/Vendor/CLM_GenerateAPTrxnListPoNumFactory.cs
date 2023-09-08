//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateAPTrxnListPoNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_GenerateAPTrxnListPoNumFactory
	{
		public ICLM_GenerateAPTrxnListPoNum Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GenerateAPTrxnListPoNum = new Logistics.Vendor.CLM_GenerateAPTrxnListPoNum(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GenerateAPTrxnListPoNumExt = timerfactory.Create<Logistics.Vendor.ICLM_GenerateAPTrxnListPoNum>(_CLM_GenerateAPTrxnListPoNum);
			
			return iCLM_GenerateAPTrxnListPoNumExt;
		}
	}
}
