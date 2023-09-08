//PROJECT NAME: Logistics
//CLASS NAME: EstItemXrefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstItemXrefFactory
	{
		public IEstItemXref Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstItemXref = new Logistics.Customer.EstItemXref(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstItemXrefExt = timerfactory.Create<Logistics.Customer.IEstItemXref>(_EstItemXref);
			
			return iEstItemXrefExt;
		}
	}
}
