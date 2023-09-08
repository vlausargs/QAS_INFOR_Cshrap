//PROJECT NAME: Production
//CLASS NAME: ResrcDelFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class ResrcDelFactory
	{
		public IResrcDel Create(IApplicationDB appDB)
		{
			var _ResrcDel = new Production.ResrcDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iResrcDelExt = timerfactory.Create<Production.IResrcDel>(_ResrcDel);
			
			return iResrcDelExt;
		}
	}
}
