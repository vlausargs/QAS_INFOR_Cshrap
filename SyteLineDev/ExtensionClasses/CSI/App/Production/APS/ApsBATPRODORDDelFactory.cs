//PROJECT NAME: Production
//CLASS NAME: ApsBATPRODORDDelFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBATPRODORDDelFactory
	{
		public IApsBATPRODORDDel Create(IApplicationDB appDB)
		{
			var _ApsBATPRODORDDel = new Production.APS.ApsBATPRODORDDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsBATPRODORDDelExt = timerfactory.Create<Production.APS.IApsBATPRODORDDel>(_ApsBATPRODORDDel);
			
			return iApsBATPRODORDDelExt;
		}
	}
}
