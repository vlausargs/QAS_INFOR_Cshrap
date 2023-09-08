//PROJECT NAME: Logistics
//CLASS NAME: InsertDoLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class InsertDoLineFactory
	{
		public IInsertDoLine Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertDoLine = new Logistics.Customer.InsertDoLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertDoLineExt = timerfactory.Create<Logistics.Customer.IInsertDoLine>(_InsertDoLine);
			
			return iInsertDoLineExt;
		}
	}
}
