//PROJECT NAME: CSICustomer
//CLASS NAME: PostEdiCoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PostEdiCoFactory
	{
		public IPostEdiCo Create(IApplicationDB appDB)
		{
			var _PostEdiCo = new Logistics.Customer.PostEdiCo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPostEdiCoExt = timerfactory.Create<Logistics.Customer.IPostEdiCo>(_PostEdiCo);
			
			return iPostEdiCoExt;
		}
	}
}
