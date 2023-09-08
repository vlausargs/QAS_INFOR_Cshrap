//PROJECT NAME: Logistics
//CLASS NAME: CreateCoPckItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CreateCoPckItemFactory
	{
		public ICreateCoPckItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateCoPckItem = new Logistics.Customer.CreateCoPckItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateCoPckItemExt = timerfactory.Create<Logistics.Customer.ICreateCoPckItem>(_CreateCoPckItem);
			
			return iCreateCoPckItemExt;
		}
	}
}
