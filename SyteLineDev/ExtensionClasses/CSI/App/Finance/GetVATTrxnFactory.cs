//PROJECT NAME: Finance
//CLASS NAME: GetVATTrxnFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class GetVATTrxnFactory
	{
		public IGetVATTrxn Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetVATTrxn = new Finance.GetVATTrxn(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVATTrxnExt = timerfactory.Create<Finance.IGetVATTrxn>(_GetVATTrxn);
			
			return iGetVATTrxnExt;
		}
	}
}
