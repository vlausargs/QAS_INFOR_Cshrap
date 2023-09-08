//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBillOfMaterialsPostFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBillOfMaterialsPostFactory
	{
		public ILoadESBBillOfMaterialsPost Create(IApplicationDB appDB)
		{
			var _LoadESBBillOfMaterialsPost = new BusInterface.LoadESBBillOfMaterialsPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBillOfMaterialsPostExt = timerfactory.Create<BusInterface.ILoadESBBillOfMaterialsPost>(_LoadESBBillOfMaterialsPost);
			
			return iLoadESBBillOfMaterialsPostExt;
		}
	}
}
