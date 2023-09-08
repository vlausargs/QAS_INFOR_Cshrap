//PROJECT NAME: CSIMaterial
//CLASS NAME: GetLotManufacturerFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetLotManufacturerFactory
	{
		public IGetLotManufacturer Create(IApplicationDB appDB)
		{
			var _GetLotManufacturer = new Material.GetLotManufacturer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetLotManufacturerExt = timerfactory.Create<Material.IGetLotManufacturer>(_GetLotManufacturer);
			
			return iGetLotManufacturerExt;
		}
	}
}
