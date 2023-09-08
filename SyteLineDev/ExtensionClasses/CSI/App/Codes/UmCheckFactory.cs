//PROJECT NAME: Codes
//CLASS NAME: UmCheckFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class UmCheckFactory
	{
		public IUmCheck Create(IApplicationDB appDB)
		{
			var _UmCheck = new Codes.UmCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUmCheckExt = timerfactory.Create<Codes.IUmCheck>(_UmCheck);
			
			return iUmCheckExt;
		}
	}
}
