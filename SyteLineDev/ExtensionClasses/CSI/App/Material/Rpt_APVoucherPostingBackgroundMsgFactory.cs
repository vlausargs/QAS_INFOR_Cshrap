//PROJECT NAME: Material
//CLASS NAME: Rpt_APVoucherPostingBackgroundMsgFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Rpt_APVoucherPostingBackgroundMsgFactory
	{
		public IRpt_APVoucherPostingBackgroundMsg Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_APVoucherPostingBackgroundMsg = new Material.Rpt_APVoucherPostingBackgroundMsg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_APVoucherPostingBackgroundMsgExt = timerfactory.Create<Material.IRpt_APVoucherPostingBackgroundMsg>(_Rpt_APVoucherPostingBackgroundMsg);
			
			return iRpt_APVoucherPostingBackgroundMsgExt;
		}
	}
}
