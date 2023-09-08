//PROJECT NAME: Production
//CLASS NAME: PSVal3Factory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSVal3Factory
	{
		public IPSVal3 Create(IApplicationDB appDB)
		{
			var _PSVal3 = new Production.PSVal3(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSVal3Ext = timerfactory.Create<Production.IPSVal3>(_PSVal3);
			
			return iPSVal3Ext;
		}
	}
}
