//PROJECT NAME: Production
//CLASS NAME: MO_CLM_EstResourceItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class MO_CLM_EstResourceItemFactory
	{
		public IMO_CLM_EstResourceItem Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_CLM_EstResourceItem = new Production.MO_CLM_EstResourceItem(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_CLM_EstResourceItemExt = timerfactory.Create<Production.IMO_CLM_EstResourceItem>(_MO_CLM_EstResourceItem);
			
			return iMO_CLM_EstResourceItemExt;
		}
	}
}
