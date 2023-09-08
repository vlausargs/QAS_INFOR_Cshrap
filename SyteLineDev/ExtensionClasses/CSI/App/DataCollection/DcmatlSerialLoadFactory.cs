//PROJECT NAME: DataCollection
//CLASS NAME: DcmatlSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcmatlSerialLoadFactory
	{
		public IDcmatlSerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcmatlSerialLoad = new DataCollection.DcmatlSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcmatlSerialLoadExt = timerfactory.Create<DataCollection.IDcmatlSerialLoad>(_DcmatlSerialLoad);
			
			return iDcmatlSerialLoadExt;
		}
	}
}
