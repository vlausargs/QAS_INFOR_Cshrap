//PROJECT NAME: CSICustomer
//CLASS NAME: GetMultiLingualDefaultTextFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetMultiLingualDefaultTextFactory
	{
		public IGetMultiLingualDefaultText Create(IApplicationDB appDB)
		{
			var _GetMultiLingualDefaultText = new Logistics.Customer.GetMultiLingualDefaultText(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMultiLingualDefaultTextExt = timerfactory.Create<Logistics.Customer.IGetMultiLingualDefaultText>(_GetMultiLingualDefaultText);
			
			return iGetMultiLingualDefaultTextExt;
		}
	}
}
