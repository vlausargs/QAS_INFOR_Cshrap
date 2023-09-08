//PROJECT NAME: Production
//CLASS NAME: ValidateResourceFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ValidateResourceFactory
	{
		public IValidateResource Create(IApplicationDB appDB)
		{
			var _ValidateResource = new Production.APS.ValidateResource(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateResourceExt = timerfactory.Create<Production.APS.IValidateResource>(_ValidateResource);
			
			return iValidateResourceExt;
		}
	}
}
