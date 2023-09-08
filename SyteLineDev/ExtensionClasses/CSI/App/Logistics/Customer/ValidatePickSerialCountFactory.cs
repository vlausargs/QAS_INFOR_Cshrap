//PROJECT NAME: Logistics
//CLASS NAME: ValidatePickSerialCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidatePickSerialCountFactory
	{
		public IValidatePickSerialCount Create(IApplicationDB appDB)
		{
			var _ValidatePickSerialCount = new Logistics.Customer.ValidatePickSerialCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePickSerialCountExt = timerfactory.Create<Logistics.Customer.IValidatePickSerialCount>(_ValidatePickSerialCount);
			
			return iValidatePickSerialCountExt;
		}
	}
}
