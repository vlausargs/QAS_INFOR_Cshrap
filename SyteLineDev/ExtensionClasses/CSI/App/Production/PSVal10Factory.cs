//PROJECT NAME: Production
//CLASS NAME: PSVal10Factory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSVal10Factory
	{
		public IPSVal10 Create(IApplicationDB appDB)
		{
			var _PSVal10 = new Production.PSVal10(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSVal10Ext = timerfactory.Create<Production.IPSVal10>(_PSVal10);
			
			return iPSVal10Ext;
		}
	}
}
