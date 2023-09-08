//PROJECT NAME: Material
//CLASS NAME: RerankItemManufacturerFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class RerankItemManufacturerFactory
	{
		public IRerankItemManufacturer Create(IApplicationDB appDB)
		{
			var _RerankItemManufacturer = new Material.RerankItemManufacturer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRerankItemManufacturerExt = timerfactory.Create<Material.IRerankItemManufacturer>(_RerankItemManufacturer);
			
			return iRerankItemManufacturerExt;
		}
	}
}
