//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidArpmtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdValidArpmtFactory
	{
		public IArpmtdValidArpmt Create(IApplicationDB appDB)
		{
			var _ArpmtdValidArpmt = new Logistics.Customer.ArpmtdValidArpmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdValidArpmtExt = timerfactory.Create<Logistics.Customer.IArpmtdValidArpmt>(_ArpmtdValidArpmt);
			
			return iArpmtdValidArpmtExt;
		}
	}
}
