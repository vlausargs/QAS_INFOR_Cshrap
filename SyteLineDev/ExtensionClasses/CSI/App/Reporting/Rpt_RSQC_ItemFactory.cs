//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_ItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RSQC_ItemFactory
	{
		public IRpt_RSQC_Item Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RSQC_Item = new Reporting.Rpt_RSQC_Item(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_ItemExt = timerfactory.Create<Reporting.IRpt_RSQC_Item>(_Rpt_RSQC_Item);
			
			return iRpt_RSQC_ItemExt;
		}
	}
}
