//PROJECT NAME: Logistics
//CLASS NAME: ConvertPoReqFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ConvertPoReqFactory
	{
		public IConvertPoReq Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ConvertPoReq = new Logistics.Vendor.ConvertPoReq(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iConvertPoReqExt = timerfactory.Create<Logistics.Vendor.IConvertPoReq>(_ConvertPoReq);
			
			return iConvertPoReqExt;
		}
	}
}
