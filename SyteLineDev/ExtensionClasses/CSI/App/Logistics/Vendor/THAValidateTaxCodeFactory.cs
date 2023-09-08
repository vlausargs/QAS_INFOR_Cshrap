//PROJECT NAME: Logistics
//CLASS NAME: THAValidateTaxCodeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THAValidateTaxCodeFactory
	{
		public ITHAValidateTaxCode Create(IApplicationDB appDB)
		{
			var _THAValidateTaxCode = new Logistics.Vendor.THAValidateTaxCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHAValidateTaxCodeExt = timerfactory.Create<Logistics.Vendor.ITHAValidateTaxCode>(_THAValidateTaxCode);
			
			return iTHAValidateTaxCodeExt;
		}
	}
}
