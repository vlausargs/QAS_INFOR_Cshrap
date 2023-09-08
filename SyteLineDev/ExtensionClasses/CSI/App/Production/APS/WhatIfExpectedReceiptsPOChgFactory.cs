//PROJECT NAME: Production
//CLASS NAME: WhatIfExpectedReceiptsPOChgFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class WhatIfExpectedReceiptsPOChgFactory
	{
		public IWhatIfExpectedReceiptsPOChg Create(IApplicationDB appDB)
		{
			var _WhatIfExpectedReceiptsPOChg = new Production.APS.WhatIfExpectedReceiptsPOChg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWhatIfExpectedReceiptsPOChgExt = timerfactory.Create<Production.APS.IWhatIfExpectedReceiptsPOChg>(_WhatIfExpectedReceiptsPOChg);
			
			return iWhatIfExpectedReceiptsPOChgExt;
		}
	}
}
