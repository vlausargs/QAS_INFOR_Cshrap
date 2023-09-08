//PROJECT NAME: Production
//CLASS NAME: PmfRptFmAddFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptFmAddFactory
	{
		public IPmfRptFmAdd Create(IApplicationDB appDB)
		{
			var _PmfRptFmAdd = new Production.ProcessManufacturing.PmfRptFmAdd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRptFmAddExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRptFmAdd>(_PmfRptFmAdd);
			
			return iPmfRptFmAddExt;
		}
	}
}
