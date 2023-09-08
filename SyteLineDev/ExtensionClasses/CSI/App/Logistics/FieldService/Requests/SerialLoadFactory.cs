//PROJECT NAME: Logistics
//CLASS NAME: SerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Requests
{
	public class SerialLoadFactory
	{
		public ISerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SerialLoad = new Logistics.FieldService.Requests.SerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSerialLoadExt = timerfactory.Create<Logistics.FieldService.Requests.ISerialLoad>(_SerialLoad);
			
			return iSerialLoadExt;
		}
	}
}
