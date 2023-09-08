//PROJECT NAME: CSICodes
//CLASS NAME: GetResellerCreatedCustomerCOFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetResellerCreatedCustomerCOFactory
	{
		public IGetResellerCreatedCustomerCO Create(IApplicationDB appDB)
		{
			var _GetResellerCreatedCustomerCO = new Codes.GetResellerCreatedCustomerCO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetResellerCreatedCustomerCOExt = timerfactory.Create<Codes.IGetResellerCreatedCustomerCO>(_GetResellerCreatedCustomerCO);
			
			return iGetResellerCreatedCustomerCOExt;
		}
	}
}
