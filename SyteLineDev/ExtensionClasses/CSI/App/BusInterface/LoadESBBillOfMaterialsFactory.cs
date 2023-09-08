//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBillOfMaterialsFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBillOfMaterialsFactory
	{
		public ILoadESBBillOfMaterials Create(IApplicationDB appDB)
		{
			var _LoadESBBillOfMaterials = new BusInterface.LoadESBBillOfMaterials(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBillOfMaterialsExt = timerfactory.Create<BusInterface.ILoadESBBillOfMaterials>(_LoadESBBillOfMaterials);
			
			return iLoadESBBillOfMaterialsExt;
		}
	}
}
