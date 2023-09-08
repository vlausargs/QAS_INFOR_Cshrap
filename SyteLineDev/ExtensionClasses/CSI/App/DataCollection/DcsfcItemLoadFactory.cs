//PROJECT NAME: DataCollection
//CLASS NAME: DcsfcItemLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcsfcItemLoadFactory
	{
		public IDcsfcItemLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcsfcItemLoad = new DataCollection.DcsfcItemLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcsfcItemLoadExt = timerfactory.Create<DataCollection.IDcsfcItemLoad>(_DcsfcItemLoad);
			
			return iDcsfcItemLoadExt;
		}
	}
}
