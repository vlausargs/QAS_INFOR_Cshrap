//PROJECT NAME: Production
//CLASS NAME: PmfPopulatePnReqWrkFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPopulatePnReqWrkFactory
	{
		public IPmfPopulatePnReqWrk Create(IApplicationDB appDB)
		{
			var _PmfPopulatePnReqWrk = new Production.ProcessManufacturing.PmfPopulatePnReqWrk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPopulatePnReqWrkExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPopulatePnReqWrk>(_PmfPopulatePnReqWrk);
			
			return iPmfPopulatePnReqWrkExt;
		}
	}
}
