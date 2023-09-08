//PROJECT NAME: DataCollection
//CLASS NAME: DcwcSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcwcSerialLoadFactory
	{
		public IDcwcSerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcwcSerialLoad = new DataCollection.DcwcSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcwcSerialLoadExt = timerfactory.Create<DataCollection.IDcwcSerialLoad>(_DcwcSerialLoad);
			
			return iDcwcSerialLoadExt;
		}
	}
}
