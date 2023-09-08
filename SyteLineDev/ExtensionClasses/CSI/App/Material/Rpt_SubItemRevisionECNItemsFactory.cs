//PROJECT NAME: Material
//CLASS NAME: Rpt_SubItemRevisionECNItemsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class Rpt_SubItemRevisionECNItemsFactory
	{
		public IRpt_SubItemRevisionECNItems Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SubItemRevisionECNItems = new Material.Rpt_SubItemRevisionECNItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SubItemRevisionECNItemsExt = timerfactory.Create<Material.IRpt_SubItemRevisionECNItems>(_Rpt_SubItemRevisionECNItems);
			
			return iRpt_SubItemRevisionECNItemsExt;
		}
	}
}
