//PROJECT NAME: Logistics
//CLASS NAME: IsUserInReprintGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class IsUserInReprintGroupFactory
	{
		public IIsUserInReprintGroup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IsUserInReprintGroup = new Logistics.Customer.IsUserInReprintGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsUserInReprintGroupExt = timerfactory.Create<Logistics.Customer.IIsUserInReprintGroup>(_IsUserInReprintGroup);
			
			return iIsUserInReprintGroupExt;
		}
	}
}
