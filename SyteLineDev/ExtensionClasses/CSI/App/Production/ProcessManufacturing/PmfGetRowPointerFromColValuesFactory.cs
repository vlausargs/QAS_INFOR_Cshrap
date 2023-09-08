//PROJECT NAME: Production
//CLASS NAME: PmfGetRowPointerFromColValuesFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfGetRowPointerFromColValuesFactory
	{
		public IPmfGetRowPointerFromColValues Create(IApplicationDB appDB)
		{
			var _PmfGetRowPointerFromColValues = new Production.ProcessManufacturing.PmfGetRowPointerFromColValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfGetRowPointerFromColValuesExt = timerfactory.Create<Production.ProcessManufacturing.IPmfGetRowPointerFromColValues>(_PmfGetRowPointerFromColValues);
			
			return iPmfGetRowPointerFromColValuesExt;
		}
	}
}
