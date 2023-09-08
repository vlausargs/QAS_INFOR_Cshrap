//PROJECT NAME: Production
//CLASS NAME: WhatIfExpectedReceiptsItemChgFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class WhatIfExpectedReceiptsItemChgFactory
	{
		public IWhatIfExpectedReceiptsItemChg Create(IApplicationDB appDB)
		{
			var _WhatIfExpectedReceiptsItemChg = new Production.APS.WhatIfExpectedReceiptsItemChg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWhatIfExpectedReceiptsItemChgExt = timerfactory.Create<Production.APS.IWhatIfExpectedReceiptsItemChg>(_WhatIfExpectedReceiptsItemChg);
			
			return iWhatIfExpectedReceiptsItemChgExt;
		}
	}
}
