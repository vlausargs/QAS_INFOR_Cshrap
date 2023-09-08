//PROJECT NAME: CSIPmf
//CLASS NAME: PmfRptMfSpecFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptMfSpecFactory
	{
		public IPmfRptMfSpec Create(IApplicationDB appDB)
		{
			var _PmfRptMfSpec = new Production.ProcessManufacturing.PmfRptMfSpec(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRptMfSpecExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRptMfSpec>(_PmfRptMfSpec);
			
			return iPmfRptMfSpecExt;
		}
	}
}
