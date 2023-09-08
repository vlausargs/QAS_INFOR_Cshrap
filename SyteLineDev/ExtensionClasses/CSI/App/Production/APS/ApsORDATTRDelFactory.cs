//PROJECT NAME: Production
//CLASS NAME: ApsORDATTRDelFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsORDATTRDelFactory
	{
		public IApsORDATTRDel Create(IApplicationDB appDB)
		{
			var _ApsORDATTRDel = new Production.APS.ApsORDATTRDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsORDATTRDelExt = timerfactory.Create<Production.APS.IApsORDATTRDel>(_ApsORDATTRDel);
			
			return iApsORDATTRDelExt;
		}
	}
}
