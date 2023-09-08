//PROJECT NAME: CSIAPS
//CLASS NAME: ChkValueFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ChkValueFactory
	{
		public IChkValue Create(IApplicationDB appDB)
		{
			var _ChkValue = new Production.APS.ChkValue(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkValueExt = timerfactory.Create<Production.APS.IChkValue>(_ChkValue);
			
			return iChkValueExt;
		}
	}
}
