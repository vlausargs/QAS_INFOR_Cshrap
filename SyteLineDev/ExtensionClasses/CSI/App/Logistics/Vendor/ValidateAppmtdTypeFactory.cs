//PROJECT NAME: Logistics
//CLASS NAME: ValidateAppmtdTypeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidateAppmtdTypeFactory
	{
		public IValidateAppmtdType Create(IApplicationDB appDB)
		{
			var _ValidateAppmtdType = new Logistics.Vendor.ValidateAppmtdType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateAppmtdTypeExt = timerfactory.Create<Logistics.Vendor.IValidateAppmtdType>(_ValidateAppmtdType);
			
			return iValidateAppmtdTypeExt;
		}
	}
}
