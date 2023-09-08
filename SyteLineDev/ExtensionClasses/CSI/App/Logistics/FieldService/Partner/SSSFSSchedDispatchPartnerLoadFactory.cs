//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedDispatchPartnerLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedDispatchPartnerLoadFactory
	{
		public ISSSFSSchedDispatchPartnerLoad Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSSchedDispatchPartnerLoad = new Logistics.FieldService.Partner.SSSFSSchedDispatchPartnerLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedDispatchPartnerLoadExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedDispatchPartnerLoad>(_SSSFSSchedDispatchPartnerLoad);
			
			return iSSSFSSchedDispatchPartnerLoadExt;
		}
	}
}
