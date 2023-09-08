//PROJECT NAME: Material
//CLASS NAME: AccountingPeriodToSalesPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class AccountingPeriodToSalesPeriodFactory
	{
		public IAccountingPeriodToSalesPeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AccountingPeriodToSalesPeriod = new Material.AccountingPeriodToSalesPeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAccountingPeriodToSalesPeriodExt = timerfactory.Create<Material.IAccountingPeriodToSalesPeriod>(_AccountingPeriodToSalesPeriod);
			
			return iAccountingPeriodToSalesPeriodExt;
		}
	}
}
