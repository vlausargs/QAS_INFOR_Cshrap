//PROJECT NAME: CSICustomer
//CLASS NAME: AU_CalculateCoLineReleasePriceFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AU_CalculateCoLineReleasePriceFactory
	{
		public IAU_CalculateCoLineReleasePrice Create(IApplicationDB appDB)
		{
			var _AU_CalculateCoLineReleasePrice = new Logistics.Customer.AU_CalculateCoLineReleasePrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_CalculateCoLineReleasePriceExt = timerfactory.Create<Logistics.Customer.IAU_CalculateCoLineReleasePrice>(_AU_CalculateCoLineReleasePrice);
			
			return iAU_CalculateCoLineReleasePriceExt;
		}
	}
}
