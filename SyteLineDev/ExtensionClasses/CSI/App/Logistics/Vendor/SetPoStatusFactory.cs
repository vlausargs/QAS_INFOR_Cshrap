//PROJECT NAME: Logistics
//CLASS NAME: SetPoStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class SetPoStatusFactory
	{
		public ISetPoStatus Create(IApplicationDB appDB)
		{
			var _SetPoStatus = new Logistics.Vendor.SetPoStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetPoStatusExt = timerfactory.Create<Logistics.Vendor.ISetPoStatus>(_SetPoStatus);
			
			return iSetPoStatusExt;
		}
	}
}
