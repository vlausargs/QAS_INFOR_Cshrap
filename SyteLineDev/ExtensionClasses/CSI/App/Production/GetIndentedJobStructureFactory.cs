//PROJECT NAME: Production
//CLASS NAME: GetIndentedJobStructureFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class GetIndentedJobStructureFactory
	{
		public IGetIndentedJobStructure Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetIndentedJobStructure = new Production.GetIndentedJobStructure(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetIndentedJobStructureExt = timerfactory.Create<Production.IGetIndentedJobStructure>(_GetIndentedJobStructure);
			
			return iGetIndentedJobStructureExt;
		}
	}
}
