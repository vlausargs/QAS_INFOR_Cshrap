//PROJECT NAME: Logistics
//CLASS NAME: SetPoBlnStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class SetPoBlnStatusFactory
	{
		public ISetPoBlnStatus Create(IApplicationDB appDB)
		{
			var _SetPoBlnStatus = new Logistics.Vendor.SetPoBlnStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetPoBlnStatusExt = timerfactory.Create<Logistics.Vendor.ISetPoBlnStatus>(_SetPoBlnStatus);
			
			return iSetPoBlnStatusExt;
		}
	}
}
