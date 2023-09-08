//PROJECT NAME: Production
//CLASS NAME: PmfGetSystemDefaultsFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetSystemDefaultsFactory
	{
		public IPmfGetSystemDefaults Create(IApplicationDB appDB)
		{
			var _PmfGetSystemDefaults = new Production.ProcessManufacturing.PmfGetSystemDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfGetSystemDefaultsExt = timerfactory.Create<Production.ProcessManufacturing.IPmfGetSystemDefaults>(_PmfGetSystemDefaults);
			
			return iPmfGetSystemDefaultsExt;
		}
	}
}
