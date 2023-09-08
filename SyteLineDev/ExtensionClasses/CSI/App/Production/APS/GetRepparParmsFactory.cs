//PROJECT NAME: Production
//CLASS NAME: GetRepparParmsFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GetRepparParmsFactory
	{
		public IGetRepparParms Create(IApplicationDB appDB)
		{
			var _GetRepparParms = new Production.APS.GetRepparParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetRepparParmsExt = timerfactory.Create<Production.APS.IGetRepparParms>(_GetRepparParms);
			
			return iGetRepparParmsExt;
		}
	}
}
