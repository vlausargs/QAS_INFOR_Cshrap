//PROJECT NAME: Reporting
//CLASS NAME: THARpt_PettyCashFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_PettyCashFactory
	{
		public ITHARpt_PettyCash Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_PettyCash = new Reporting.THARpt_PettyCash(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_PettyCashExt = timerfactory.Create<Reporting.ITHARpt_PettyCash>(_THARpt_PettyCash);
			
			return iTHARpt_PettyCashExt;
		}
	}
}
