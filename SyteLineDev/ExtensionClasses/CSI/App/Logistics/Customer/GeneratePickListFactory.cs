//PROJECT NAME: CSICustomer
//CLASS NAME: GeneratePickListFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GeneratePickListFactory
	{
		public IGeneratePickList Create(IApplicationDB appDB)
		{
			var _GeneratePickList = new Logistics.Customer.GeneratePickList(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGeneratePickListExt = timerfactory.Create<Logistics.Customer.IGeneratePickList>(_GeneratePickList);
			
			return iGeneratePickListExt;
		}
	}
}
