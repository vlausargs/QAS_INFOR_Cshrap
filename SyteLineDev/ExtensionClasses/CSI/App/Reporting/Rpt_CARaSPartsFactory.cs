//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CARaSPartsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CARaSPartsFactory
	{
		public IRpt_CARaSParts Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CARaSParts = new Reporting.Rpt_CARaSParts(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CARaSPartsExt = timerfactory.Create<Reporting.IRpt_CARaSParts>(_Rpt_CARaSParts);
			
			return iRpt_CARaSPartsExt;
		}
	}
}
