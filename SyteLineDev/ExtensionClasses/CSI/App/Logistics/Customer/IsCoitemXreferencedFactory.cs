//PROJECT NAME: Logistics
//CLASS NAME: IsCoitemXreferencedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class IsCoitemXreferencedFactory
	{
		public IIsCoitemXreferenced Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsCoitemXreferenced = new Logistics.Customer.IsCoitemXreferenced(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsCoitemXreferencedExt = timerfactory.Create<Logistics.Customer.IIsCoitemXreferenced>(_IsCoitemXreferenced);
			
			return iIsCoitemXreferencedExt;
		}
	}
}
