//PROJECT NAME: Production
//CLASS NAME: MO_CLM_ResourceItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class MO_CLM_ResourceItemFactory
	{
		public IMO_CLM_ResourceItem Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_CLM_ResourceItem = new Production.MO_CLM_ResourceItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_CLM_ResourceItemExt = timerfactory.Create<Production.IMO_CLM_ResourceItem>(_MO_CLM_ResourceItem);
			
			return iMO_CLM_ResourceItemExt;
		}
	}
}
