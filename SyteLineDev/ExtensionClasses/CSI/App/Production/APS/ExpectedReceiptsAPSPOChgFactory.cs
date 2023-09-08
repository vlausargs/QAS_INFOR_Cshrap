//PROJECT NAME: CSIAPS
//CLASS NAME: ExpectedReceiptsAPSPOChgFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ExpectedReceiptsAPSPOChgFactory
	{
		public IExpectedReceiptsAPSPOChg Create(IApplicationDB appDB)
		{
			var _ExpectedReceiptsAPSPOChg = new Production.APS.ExpectedReceiptsAPSPOChg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExpectedReceiptsAPSPOChgExt = timerfactory.Create<Production.APS.IExpectedReceiptsAPSPOChg>(_ExpectedReceiptsAPSPOChg);
			
			return iExpectedReceiptsAPSPOChgExt;
		}
	}
}
