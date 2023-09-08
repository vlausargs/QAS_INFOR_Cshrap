//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPartTmpLoadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSPartTmpLoadFactory
	{
		public ISSSFSPartTmpLoad Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSPartTmpLoad = new Logistics.FieldService.Partner.SSSFSPartTmpLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPartTmpLoadExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSPartTmpLoad>(_SSSFSPartTmpLoad);
			
			return iSSSFSPartTmpLoadExt;
		}
	}
}
