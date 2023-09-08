//PROJECT NAME: Material
//CLASS NAME: Rpt_InvoicePostingBackgroundMsgFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Rpt_InvoicePostingBackgroundMsgFactory
	{
		public IRpt_InvoicePostingBackgroundMsg Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoicePostingBackgroundMsg = new Material.Rpt_InvoicePostingBackgroundMsg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoicePostingBackgroundMsgExt = timerfactory.Create<Material.IRpt_InvoicePostingBackgroundMsg>(_Rpt_InvoicePostingBackgroundMsg);
			
			return iRpt_InvoicePostingBackgroundMsgExt;
		}
	}
}
