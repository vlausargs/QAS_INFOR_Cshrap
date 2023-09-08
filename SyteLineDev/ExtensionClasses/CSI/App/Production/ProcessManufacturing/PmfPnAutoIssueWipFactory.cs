//PROJECT NAME: Production
//CLASS NAME: PmfPnAutoIssueWipFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfPnAutoIssueWipFactory
	{
		public IPmfPnAutoIssueWip Create(IApplicationDB appDB)
		{
			var _PmfPnAutoIssueWip = new Production.ProcessManufacturing.PmfPnAutoIssueWip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfPnAutoIssueWipExt = timerfactory.Create<Production.ProcessManufacturing.IPmfPnAutoIssueWip>(_PmfPnAutoIssueWip);
			
			return iPmfPnAutoIssueWipExt;
		}
	}
}
