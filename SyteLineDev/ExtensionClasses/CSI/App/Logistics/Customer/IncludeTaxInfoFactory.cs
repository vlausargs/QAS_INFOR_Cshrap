//PROJECT NAME: CSICustomer
//CLASS NAME: IncludeTaxInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class IncludeTaxInfoFactory
	{
		public IIncludeTaxInfo Create(IApplicationDB appDB)
		{
			var _IncludeTaxInfo = new Logistics.Customer.IncludeTaxInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIncludeTaxInfoExt = timerfactory.Create<Logistics.Customer.IIncludeTaxInfo>(_IncludeTaxInfo);
			
			return iIncludeTaxInfoExt;
		}
	}
}
