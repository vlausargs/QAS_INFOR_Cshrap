//PROJECT NAME: Codes
//CLASS NAME: GetStartupParmsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetStartupParmsFactory
	{
		public IGetStartupParms Create(IApplicationDB appDB)
		{
			var _GetStartupParms = new Codes.GetStartupParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetStartupParmsExt = timerfactory.Create<Codes.IGetStartupParms>(_GetStartupParms);
			
			return iGetStartupParmsExt;
		}
	}
}
