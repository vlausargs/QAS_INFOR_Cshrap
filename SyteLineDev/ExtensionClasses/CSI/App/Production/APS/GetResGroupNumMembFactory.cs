//PROJECT NAME: Production
//CLASS NAME: GetResGroupNumMembFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GetResGroupNumMembFactory
	{
		public IGetResGroupNumMemb Create(IApplicationDB appDB)
		{
			var _GetResGroupNumMemb = new Production.APS.GetResGroupNumMemb(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetResGroupNumMembExt = timerfactory.Create<Production.APS.IGetResGroupNumMemb>(_GetResGroupNumMemb);
			
			return iGetResGroupNumMembExt;
		}
	}
}
