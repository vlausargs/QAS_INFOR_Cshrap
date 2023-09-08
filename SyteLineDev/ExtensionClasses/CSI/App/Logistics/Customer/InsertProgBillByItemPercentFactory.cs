//PROJECT NAME: Logistics
//CLASS NAME: InsertProgBillByItemPercentFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InsertProgBillByItemPercentFactory
	{
		public IInsertProgBillByItemPercent Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertProgBillByItemPercent = new Logistics.Customer.InsertProgBillByItemPercent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertProgBillByItemPercentExt = timerfactory.Create<Logistics.Customer.IInsertProgBillByItemPercent>(_InsertProgBillByItemPercent);
			
			return iInsertProgBillByItemPercentExt;
		}
	}
}
