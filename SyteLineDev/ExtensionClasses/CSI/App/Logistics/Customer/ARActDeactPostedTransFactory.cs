//PROJECT NAME: CSICustomer
//CLASS NAME: ARActDeactPostedTransFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARActDeactPostedTransFactory
	{
		public IARActDeactPostedTrans Create(IApplicationDB appDB)
		{
			var _ARActDeactPostedTrans = new Logistics.Customer.ARActDeactPostedTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARActDeactPostedTransExt = timerfactory.Create<Logistics.Customer.IARActDeactPostedTrans>(_ARActDeactPostedTrans);
			
			return iARActDeactPostedTransExt;
		}
	}
}
