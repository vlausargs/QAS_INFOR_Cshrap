//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcSerialLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcsfcSerialLoadFactory
	{
		public IDcsfcSerialLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcsfcSerialLoad = new DataCollection.DcsfcSerialLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcsfcSerialLoadExt = timerfactory.Create<DataCollection.IDcsfcSerialLoad>(_DcsfcSerialLoad);
			
			return iDcsfcSerialLoadExt;
		}
	}
}
