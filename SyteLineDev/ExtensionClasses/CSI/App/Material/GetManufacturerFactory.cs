//PROJECT NAME: CSIMaterial
//CLASS NAME: GetManufacturerFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetManufacturerFactory
	{
		public IGetManufacturer Create(IApplicationDB appDB)
		{
			var _GetManufacturer = new Material.GetManufacturer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetManufacturerExt = timerfactory.Create<Material.IGetManufacturer>(_GetManufacturer);
			
			return iGetManufacturerExt;
		}
	}
}
