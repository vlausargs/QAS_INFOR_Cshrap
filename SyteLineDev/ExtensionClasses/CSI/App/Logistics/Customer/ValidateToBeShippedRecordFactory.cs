//PROJECT NAME: Logistics
//CLASS NAME: ValidateToBeShippedRecordFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ValidateToBeShippedRecordFactory
	{
		public IValidateToBeShippedRecord Create(IApplicationDB appDB)
		{
			var _ValidateToBeShippedRecord = new Logistics.Customer.ValidateToBeShippedRecord(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateToBeShippedRecordExt = timerfactory.Create<Logistics.Customer.IValidateToBeShippedRecord>(_ValidateToBeShippedRecord);
			
			return iValidateToBeShippedRecordExt;
		}
	}
}
