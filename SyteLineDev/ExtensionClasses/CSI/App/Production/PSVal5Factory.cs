//PROJECT NAME: Production
//CLASS NAME: PSVal5Factory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSVal5Factory
	{
		public IPSVal5 Create(IApplicationDB appDB)
		{
			var _PSVal5 = new Production.PSVal5(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSVal5Ext = timerfactory.Create<Production.IPSVal5>(_PSVal5);
			
			return iPSVal5Ext;
		}
	}
}
