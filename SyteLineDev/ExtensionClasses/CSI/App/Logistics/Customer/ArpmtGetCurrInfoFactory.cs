//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtGetCurrInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtGetCurrInfoFactory
	{
		public IArpmtGetCurrInfo Create(IApplicationDB appDB)
		{
			var _ArpmtGetCurrInfo = new Logistics.Customer.ArpmtGetCurrInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtGetCurrInfoExt = timerfactory.Create<Logistics.Customer.IArpmtGetCurrInfo>(_ArpmtGetCurrInfo);
			
			return iArpmtGetCurrInfoExt;
		}
	}
}
