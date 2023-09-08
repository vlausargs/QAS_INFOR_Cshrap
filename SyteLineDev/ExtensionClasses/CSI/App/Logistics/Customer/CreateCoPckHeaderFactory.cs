//PROJECT NAME: Logistics
//CLASS NAME: CreateCoPckHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CreateCoPckHeaderFactory
	{
		public ICreateCoPckHeader Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreateCoPckHeader = new Logistics.Customer.CreateCoPckHeader(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateCoPckHeaderExt = timerfactory.Create<Logistics.Customer.ICreateCoPckHeader>(_CreateCoPckHeader);
			
			return iCreateCoPckHeaderExt;
		}
	}
}
