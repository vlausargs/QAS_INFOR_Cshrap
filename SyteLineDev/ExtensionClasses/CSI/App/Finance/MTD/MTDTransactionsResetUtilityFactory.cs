//PROJECT NAME: Finance
//CLASS NAME: MTDTransactionsResetUtilityFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class MTDTransactionsResetUtilityFactory
	{
		public IMTDTransactionsResetUtility Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _MTDTransactionsResetUtility = new Finance.MTDTransactionsResetUtility(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMTDTransactionsResetUtilityExt = timerfactory.Create<Finance.IMTDTransactionsResetUtility>(_MTDTransactionsResetUtility);
			
			return iMTDTransactionsResetUtilityExt;
		}
	}
}
