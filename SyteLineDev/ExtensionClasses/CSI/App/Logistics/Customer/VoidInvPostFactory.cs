//PROJECT NAME: Logistics
//CLASS NAME: VoidInvPostFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class VoidInvPostFactory
	{
		public IVoidInvPost Create(IApplicationDB appDB)
		{
			var _VoidInvPost = new Logistics.Customer.VoidInvPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidInvPostExt = timerfactory.Create<Logistics.Customer.IVoidInvPost>(_VoidInvPost);
			
			return iVoidInvPostExt;
		}
	}
}
