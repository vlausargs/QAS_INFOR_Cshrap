//PROJECT NAME: DataCollection
//CLASS NAME: DcpsSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcpsSerialLoadFactory
	{
		public IDcpsSerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcpsSerialLoad = new DataCollection.DcpsSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcpsSerialLoadExt = timerfactory.Create<DataCollection.IDcpsSerialLoad>(_DcpsSerialLoad);
			
			return iDcpsSerialLoadExt;
		}
	}
}
