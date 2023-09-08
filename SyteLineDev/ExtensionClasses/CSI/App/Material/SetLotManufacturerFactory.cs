//PROJECT NAME: Material
//CLASS NAME: SetLotManufacturerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class SetLotManufacturerFactory
	{
		public ISetLotManufacturer Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SetLotManufacturer = new Material.SetLotManufacturer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetLotManufacturerExt = timerfactory.Create<Material.ISetLotManufacturer>(_SetLotManufacturer);
			
			return iSetLotManufacturerExt;
		}
	}
}
