//PROJECT NAME: CSICodes
//CLASS NAME: GetSiteCompanyInfoFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetSiteCompanyInfoFactory
	{
		public IGetSiteCompanyInfo Create(IApplicationDB appDB)
		{
			var _GetSiteCompanyInfo = new Codes.GetSiteCompanyInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSiteCompanyInfoExt = timerfactory.Create<Codes.IGetSiteCompanyInfo>(_GetSiteCompanyInfo);
			
			return iGetSiteCompanyInfoExt;
		}
	}
}
