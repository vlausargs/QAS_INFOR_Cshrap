//PROJECT NAME: CSICustomer
//CLASS NAME: ARPayPostUpdateTmpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARPayPostUpdateTmpFactory
	{
		public IARPayPostUpdateTmp Create(IApplicationDB appDB)
		{
			var _ARPayPostUpdateTmp = new Logistics.Customer.ARPayPostUpdateTmp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPayPostUpdateTmpExt = timerfactory.Create<Logistics.Customer.IARPayPostUpdateTmp>(_ARPayPostUpdateTmp);
			
			return iARPayPostUpdateTmpExt;
		}
	}
}
