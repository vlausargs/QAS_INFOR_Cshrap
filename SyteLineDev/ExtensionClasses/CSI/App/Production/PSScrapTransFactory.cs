//PROJECT NAME: Production
//CLASS NAME: PSScrapTransFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSScrapTransFactory
	{
		public IPSScrapTrans Create(IApplicationDB appDB)
		{
			var _PSScrapTrans = new Production.PSScrapTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSScrapTransExt = timerfactory.Create<Production.IPSScrapTrans>(_PSScrapTrans);
			
			return iPSScrapTransExt;
		}
	}
}
