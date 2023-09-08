//PROJECT NAME: CSIAPS
//CLASS NAME: GetInvSumStartEndDatFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GetInvSumStartEndDatFactory
	{
		public IGetInvSumStartEndDat Create(IApplicationDB appDB)
		{
			var _GetInvSumStartEndDat = new Production.APS.GetInvSumStartEndDat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInvSumStartEndDatExt = timerfactory.Create<Production.APS.IGetInvSumStartEndDat>(_GetInvSumStartEndDat);
			
			return iGetInvSumStartEndDatExt;
		}
	}
}
