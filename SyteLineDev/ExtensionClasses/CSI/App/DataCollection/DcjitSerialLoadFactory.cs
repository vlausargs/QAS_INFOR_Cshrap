//PROJECT NAME: DataCollection
//CLASS NAME: DcjitSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcjitSerialLoadFactory
	{
		public IDcjitSerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcjitSerialLoad = new DataCollection.DcjitSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcjitSerialLoadExt = timerfactory.Create<DataCollection.IDcjitSerialLoad>(_DcjitSerialLoad);
			
			return iDcjitSerialLoadExt;
		}
	}
}
