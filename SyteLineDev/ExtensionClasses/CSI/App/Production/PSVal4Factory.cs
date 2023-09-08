//PROJECT NAME: Production
//CLASS NAME: PSVal4Factory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSVal4Factory
	{
		public IPSVal4 Create(IApplicationDB appDB)
		{
			var _PSVal4 = new Production.PSVal4(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSVal4Ext = timerfactory.Create<Production.IPSVal4>(_PSVal4);
			
			return iPSVal4Ext;
		}
	}
}
