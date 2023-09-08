//PROJECT NAME: CSIFinance
//CLASS NAME: GetSiteTypeFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GetSiteTypeFactory
	{
		public IGetSiteType Create(IApplicationDB appDB)
		{
			var _GetSiteType = new Finance.GetSiteType(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSiteTypeExt = timerfactory.Create<Finance.IGetSiteType>(_GetSiteType);
			
			return iGetSiteTypeExt;
		}
	}
}
