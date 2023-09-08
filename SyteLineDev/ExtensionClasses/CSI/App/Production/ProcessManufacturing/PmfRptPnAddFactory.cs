//PROJECT NAME: Production
//CLASS NAME: PmfRptPnAddFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptPnAddFactory
	{
		public IPmfRptPnAdd Create(IApplicationDB appDB)
		{
			var _PmfRptPnAdd = new Production.ProcessManufacturing.PmfRptPnAdd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRptPnAddExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRptPnAdd>(_PmfRptPnAdd);
			
			return iPmfRptPnAddExt;
		}
	}
}
