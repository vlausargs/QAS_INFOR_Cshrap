//PROJECT NAME: Production
//CLASS NAME: PmfGetNextContainerNumFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetNextContainerNumFactory
	{
		public IPmfGetNextContainerNum Create(IApplicationDB appDB)
		{
			var _PmfGetNextContainerNum = new Production.ProcessManufacturing.PmfGetNextContainerNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfGetNextContainerNumExt = timerfactory.Create<Production.ProcessManufacturing.IPmfGetNextContainerNum>(_PmfGetNextContainerNum);
			
			return iPmfGetNextContainerNumExt;
		}
	}
}
