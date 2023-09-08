//PROJECT NAME: Material
//CLASS NAME: Rpt_ARFinanceChargePostingBackgroundMsgFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Rpt_ARFinanceChargePostingBackgroundMsgFactory
	{
		public IRpt_ARFinanceChargePostingBackgroundMsg Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARFinanceChargePostingBackgroundMsg = new Material.Rpt_ARFinanceChargePostingBackgroundMsg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARFinanceChargePostingBackgroundMsgExt = timerfactory.Create<Material.IRpt_ARFinanceChargePostingBackgroundMsg>(_Rpt_ARFinanceChargePostingBackgroundMsg);
			
			return iRpt_ARFinanceChargePostingBackgroundMsgExt;
		}
	}
}
