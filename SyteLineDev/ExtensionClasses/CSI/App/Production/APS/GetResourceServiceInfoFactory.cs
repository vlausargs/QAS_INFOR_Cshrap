//PROJECT NAME: CSIAPS
//CLASS NAME: GetResourceServiceInfoFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GetResourceServiceInfoFactory
	{
		public IGetResourceServiceInfo Create(IApplicationDB appDB)
		{
			var _GetResourceServiceInfo = new Production.APS.GetResourceServiceInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetResourceServiceInfoExt = timerfactory.Create<Production.APS.IGetResourceServiceInfo>(_GetResourceServiceInfo);
			
			return iGetResourceServiceInfoExt;
		}
	}
}
