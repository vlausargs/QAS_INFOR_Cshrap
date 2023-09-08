//PROJECT NAME: DataCollection
//CLASS NAME: DcmoveSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcmoveSerialLoadFactory
	{
		public IDcmoveSerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcmoveSerialLoad = new DataCollection.DcmoveSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmoveSerialLoadExt = timerfactory.Create<DataCollection.IDcmoveSerialLoad>(_DcmoveSerialLoad);
			
			return iDcmoveSerialLoadExt;
		}
	}
}
