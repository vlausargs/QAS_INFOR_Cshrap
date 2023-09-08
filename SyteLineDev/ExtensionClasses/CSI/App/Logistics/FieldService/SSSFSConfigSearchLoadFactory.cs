//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConfigSearchLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConfigSearchLoadFactory
	{
		public ISSSFSConfigSearchLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSConfigSearchLoad = new Logistics.FieldService.SSSFSConfigSearchLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConfigSearchLoadExt = timerfactory.Create<Logistics.FieldService.ISSSFSConfigSearchLoad>(_SSSFSConfigSearchLoad);
			
			return iSSSFSConfigSearchLoadExt;
		}
	}
}
