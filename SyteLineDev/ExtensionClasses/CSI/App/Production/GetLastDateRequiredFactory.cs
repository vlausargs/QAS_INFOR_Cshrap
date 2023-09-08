//PROJECT NAME: CSIProduct
//CLASS NAME: GetLastDateRequiredFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class GetLastDateRequiredFactory
	{
		public IGetLastDateRequired Create(IApplicationDB appDB)
		{
			var _GetLastDateRequired = new Production.GetLastDateRequired(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetLastDateRequiredExt = timerfactory.Create<Production.IGetLastDateRequired>(_GetLastDateRequired);
			
			return iGetLastDateRequiredExt;
		}
	}
}
