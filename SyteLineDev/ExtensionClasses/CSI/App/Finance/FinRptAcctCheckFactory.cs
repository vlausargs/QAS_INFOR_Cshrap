//PROJECT NAME: Finance
//CLASS NAME: FinRptAcctCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class FinRptAcctCheckFactory
	{
		public IFinRptAcctCheck Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FinRptAcctCheck = new Finance.FinRptAcctCheck(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptAcctCheckExt = timerfactory.Create<Finance.IFinRptAcctCheck>(_FinRptAcctCheck);
			
			return iFinRptAcctCheckExt;
		}
	}
}
