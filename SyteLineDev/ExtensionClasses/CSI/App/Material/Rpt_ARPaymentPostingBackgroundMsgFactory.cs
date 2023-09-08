//PROJECT NAME: Material
//CLASS NAME: Rpt_ARPaymentPostingBackgroundMsgFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Rpt_ARPaymentPostingBackgroundMsgFactory
	{
		public IRpt_ARPaymentPostingBackgroundMsg Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARPaymentPostingBackgroundMsg = new Material.Rpt_ARPaymentPostingBackgroundMsg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARPaymentPostingBackgroundMsgExt = timerfactory.Create<Material.IRpt_ARPaymentPostingBackgroundMsg>(_Rpt_ARPaymentPostingBackgroundMsg);
			
			return iRpt_ARPaymentPostingBackgroundMsgExt;
		}
	}
}
