//PROJECT NAME: Logistics
//CLASS NAME: UpdateParmsRsvd1Factory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateParmsRsvd1Factory
	{
		public IUpdateParmsRsvd1 Create(IApplicationDB appDB)
		{
			var _UpdateParmsRsvd1 = new Logistics.Customer.UpdateParmsRsvd1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateParmsRsvd1Ext = timerfactory.Create<Logistics.Customer.IUpdateParmsRsvd1>(_UpdateParmsRsvd1);
			
			return iUpdateParmsRsvd1Ext;
		}
	}
}
