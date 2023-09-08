//PROJECT NAME: Finance
//CLASS NAME: AcctDBFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class AcctDBFactory
	{
		public IAcctDB Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AcctDB = new Finance.AcctDB(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAcctDBExt = timerfactory.Create<Finance.IAcctDB>(_AcctDB);

			return iAcctDBExt;
		}
	}
}
