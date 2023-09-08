//PROJECT NAME: Production
//CLASS NAME: PSDelFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class PSDelFactory
	{
		public IPSDel Create(IApplicationDB appDB)
		{
			var _PSDel = new Production.PSDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPSDelExt = timerfactory.Create<Production.IPSDel>(_PSDel);
			
			return iPSDelExt;
		}
	}
}
