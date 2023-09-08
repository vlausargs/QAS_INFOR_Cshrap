//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MyProjectVariancesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Homepage_MyProjectVariancesFactory
	{
		public IHomepage_MyProjectVariances Create(IApplicationDB appDB)
		{
			var _Homepage_MyProjectVariances = new Logistics.Customer.Homepage_MyProjectVariances(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_MyProjectVariancesExt = timerfactory.Create<Logistics.Customer.IHomepage_MyProjectVariances>(_Homepage_MyProjectVariances);
			
			return iHomepage_MyProjectVariancesExt;
		}
	}
}
