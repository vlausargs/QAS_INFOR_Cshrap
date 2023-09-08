//PROJECT NAME: Logistics
//CLASS NAME: ZeroItemCustVendYTDPTDFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ZeroItemCustVendYTDPTDFactory
	{
		public IZeroItemCustVendYTDPTD Create(IApplicationDB appDB)
		{
			var _ZeroItemCustVendYTDPTD = new Logistics.Customer.ZeroItemCustVendYTDPTD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iZeroItemCustVendYTDPTDExt = timerfactory.Create<Logistics.Customer.IZeroItemCustVendYTDPTD>(_ZeroItemCustVendYTDPTD);
			
			return iZeroItemCustVendYTDPTDExt;
		}
	}
}
