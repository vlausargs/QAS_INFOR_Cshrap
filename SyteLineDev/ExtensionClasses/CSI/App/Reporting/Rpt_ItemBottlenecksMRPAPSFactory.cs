//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemBottlenecksMRPAPSFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemBottlenecksMRPAPSFactory
	{
		public IRpt_ItemBottlenecksMRPAPS Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemBottlenecksMRPAPS = new Reporting.Rpt_ItemBottlenecksMRPAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemBottlenecksMRPAPSExt = timerfactory.Create<Reporting.IRpt_ItemBottlenecksMRPAPS>(_Rpt_ItemBottlenecksMRPAPS);
			
			return iRpt_ItemBottlenecksMRPAPSExt;
		}
	}
}
