//PROJECT NAME: Production
//CLASS NAME: UpdateResourceSchedFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class UpdateResourceSchedFactory
	{
		public IUpdateResourceSched Create(IApplicationDB appDB)
		{
			var _UpdateResourceSched = new Production.UpdateResourceSched(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateResourceSchedExt = timerfactory.Create<Production.IUpdateResourceSched>(_UpdateResourceSched);
			
			return iUpdateResourceSchedExt;
		}
	}
}
