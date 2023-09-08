//PROJECT NAME: Production
//CLASS NAME: LeaveItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class LeaveItemFactory
	{
		public ILeaveItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LeaveItem = new Production.LeaveItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLeaveItemExt = timerfactory.Create<Production.ILeaveItem>(_LeaveItem);
			
			return iLeaveItemExt;
		}
	}
}
