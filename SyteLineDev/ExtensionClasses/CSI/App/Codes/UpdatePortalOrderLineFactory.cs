//PROJECT NAME: CSICodes
//CLASS NAME: UpdatePortalOrderLineFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class UpdatePortalOrderLineFactory
	{
		public IUpdatePortalOrderLine Create(IApplicationDB appDB)
		{
			var _UpdatePortalOrderLine = new Codes.UpdatePortalOrderLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdatePortalOrderLineExt = timerfactory.Create<Codes.IUpdatePortalOrderLine>(_UpdatePortalOrderLine);
			
			return iUpdatePortalOrderLineExt;
		}
	}
}
