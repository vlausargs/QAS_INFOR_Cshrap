//PROJECT NAME: Production
//CLASS NAME: PmfRptSpecAddFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRptSpecAddFactory
	{
		public IPmfRptSpecAdd Create(IApplicationDB appDB)
		{
			var _PmfRptSpecAdd = new Production.ProcessManufacturing.PmfRptSpecAdd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRptSpecAddExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRptSpecAdd>(_PmfRptSpecAdd);
			
			return iPmfRptSpecAddExt;
		}
	}
}
