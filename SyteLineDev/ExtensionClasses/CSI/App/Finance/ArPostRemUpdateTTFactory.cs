//PROJECT NAME: CSIFinance
//CLASS NAME: ArPostRemUpdateTTFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ArPostRemUpdateTTFactory
	{
		public IArPostRemUpdateTT Create(IApplicationDB appDB)
		{
			var _ArPostRemUpdateTT = new Finance.ArPostRemUpdateTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArPostRemUpdateTTExt = timerfactory.Create<Finance.IArPostRemUpdateTT>(_ArPostRemUpdateTT);
			
			return iArPostRemUpdateTTExt;
		}
	}
}
