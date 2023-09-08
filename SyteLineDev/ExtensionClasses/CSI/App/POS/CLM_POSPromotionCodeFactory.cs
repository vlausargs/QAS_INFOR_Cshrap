//PROJECT NAME: POS
//CLASS NAME: CLM_POSPromotionCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.POS
{
	public class CLM_POSPromotionCodeFactory
	{
		public ICLM_POSPromotionCode Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_POSPromotionCode = new POS.CLM_POSPromotionCode(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_POSPromotionCodeExt = timerfactory.Create<POS.ICLM_POSPromotionCode>(_CLM_POSPromotionCode);
			
			return iCLM_POSPromotionCodeExt;
		}
	}
}
