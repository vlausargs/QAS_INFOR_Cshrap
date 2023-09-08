//PROJECT NAME: Material
//CLASS NAME: GetIndentedCurrentJobStructureFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class GetIndentedCurrentJobStructureFactory
	{
		public IGetIndentedCurrentJobStructure Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetIndentedCurrentJobStructure = new Material.GetIndentedCurrentJobStructure(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetIndentedCurrentJobStructureExt = timerfactory.Create<Material.IGetIndentedCurrentJobStructure>(_GetIndentedCurrentJobStructure);
			
			return iGetIndentedCurrentJobStructureExt;
		}
	}
}
