//PROJECT NAME: Finance
//CLASS NAME: MultiFSBPerGetFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBPerGetFactory
	{
		public IMultiFSBPerGet Create(IApplicationDB appDB)
		{
			var _MultiFSBPerGet = new Finance.MultiFSBPerGet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBPerGetExt = timerfactory.Create<Finance.IMultiFSBPerGet>(_MultiFSBPerGet);
			
			return iMultiFSBPerGetExt;
		}
	}
}
