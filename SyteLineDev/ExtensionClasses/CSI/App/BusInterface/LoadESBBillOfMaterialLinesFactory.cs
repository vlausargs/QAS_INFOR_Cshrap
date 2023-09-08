//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBillOfMaterialLinesFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBBillOfMaterialLinesFactory
	{
		public ILoadESBBillOfMaterialLines Create(IApplicationDB appDB)
		{
			var _LoadESBBillOfMaterialLines = new BusInterface.LoadESBBillOfMaterialLines(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBBillOfMaterialLinesExt = timerfactory.Create<BusInterface.ILoadESBBillOfMaterialLines>(_LoadESBBillOfMaterialLines);
			
			return iLoadESBBillOfMaterialLinesExt;
		}
	}
}
