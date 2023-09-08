//PROJECT NAME: CSICodes
//CLASS NAME: GetCustPortalOrderInfoFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetCustPortalOrderInfoFactory
	{
		public IGetCustPortalOrderInfo Create(IApplicationDB appDB)
		{
			var _GetCustPortalOrderInfo = new Codes.GetCustPortalOrderInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustPortalOrderInfoExt = timerfactory.Create<Codes.IGetCustPortalOrderInfo>(_GetCustPortalOrderInfo);
			
			return iGetCustPortalOrderInfoExt;
		}
	}
}
