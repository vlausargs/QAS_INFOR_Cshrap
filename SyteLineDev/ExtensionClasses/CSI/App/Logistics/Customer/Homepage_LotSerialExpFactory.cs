//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_LotSerialExpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Homepage_LotSerialExpFactory
	{
		public IHomepage_LotSerialExp Create(IApplicationDB appDB)
		{
			var _Homepage_LotSerialExp = new Logistics.Customer.Homepage_LotSerialExp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_LotSerialExpExt = timerfactory.Create<Logistics.Customer.IHomepage_LotSerialExp>(_Homepage_LotSerialExp);
			
			return iHomepage_LotSerialExpExt;
		}
	}
}
