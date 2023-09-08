//PROJECT NAME: CSIAPS
//CLASS NAME: ChkNumdbFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ChkNumdbFactory
	{
		public IChkNumdb Create(IApplicationDB appDB)
		{
			var _ChkNumdb = new Production.APS.ChkNumdb(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkNumdbExt = timerfactory.Create<Production.APS.IChkNumdb>(_ChkNumdb);
			
			return iChkNumdbExt;
		}
	}
}
