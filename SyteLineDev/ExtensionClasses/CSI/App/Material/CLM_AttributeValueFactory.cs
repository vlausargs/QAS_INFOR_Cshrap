//PROJECT NAME: Material
//CLASS NAME: CLM_AttributeValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_AttributeValueFactory
	{
		public ICLM_AttributeValue Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_AttributeValue = new Material.CLM_AttributeValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_AttributeValueExt = timerfactory.Create<Material.ICLM_AttributeValue>(_CLM_AttributeValue);
			
			return iCLM_AttributeValueExt;
		}
	}
}
