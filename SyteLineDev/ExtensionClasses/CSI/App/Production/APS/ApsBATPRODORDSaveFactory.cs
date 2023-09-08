//PROJECT NAME: Production
//CLASS NAME: ApsBATPRODORDSaveFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsBATPRODORDSaveFactory
	{
		public IApsBATPRODORDSave Create(IApplicationDB appDB)
		{
			var _ApsBATPRODORDSave = new Production.APS.ApsBATPRODORDSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsBATPRODORDSaveExt = timerfactory.Create<Production.APS.IApsBATPRODORDSave>(_ApsBATPRODORDSave);
			
			return iApsBATPRODORDSaveExt;
		}
	}
}
