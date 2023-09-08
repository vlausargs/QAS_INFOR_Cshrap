//PROJECT NAME: DataCollection
//CLASS NAME: DcpoSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcpoSerialLoadFactory
	{
		public IDcpoSerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcpoSerialLoad = new DataCollection.DcpoSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpoSerialLoadExt = timerfactory.Create<DataCollection.IDcpoSerialLoad>(_DcpoSerialLoad);
			
			return iDcpoSerialLoadExt;
		}
	}
}
