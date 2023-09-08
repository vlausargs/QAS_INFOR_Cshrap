//PROJECT NAME: Codes
//CLASS NAME: DistacctTransferAccountsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class DistacctTransferAccountsFactory
	{
		public IDistacctTransferAccounts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DistacctTransferAccounts = new Codes.DistacctTransferAccounts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDistacctTransferAccountsExt = timerfactory.Create<Codes.IDistacctTransferAccounts>(_DistacctTransferAccounts);
			
			return iDistacctTransferAccountsExt;
		}
	}
}
