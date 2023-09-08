//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectResourceKitPickListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectResourceKitPickListFactory
	{
		public IRpt_ProjectResourceKitPickList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectResourceKitPickList = new Reporting.Rpt_ProjectResourceKitPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectResourceKitPickListExt = timerfactory.Create<Reporting.IRpt_ProjectResourceKitPickList>(_Rpt_ProjectResourceKitPickList);
			
			return iRpt_ProjectResourceKitPickListExt;
		}
	}
}
