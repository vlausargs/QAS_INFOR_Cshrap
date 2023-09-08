//PROJECT NAME: CSIMaterial
//CLASS NAME: MisReceiptItemWhseGetCostValuesFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class MisReceiptItemWhseGetCostValuesFactory
	{
		public IMisReceiptItemWhseGetCostValues Create(IApplicationDB appDB)
		{
			var _MisReceiptItemWhseGetCostValues = new Material.MisReceiptItemWhseGetCostValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMisReceiptItemWhseGetCostValuesExt = timerfactory.Create<Material.IMisReceiptItemWhseGetCostValues>(_MisReceiptItemWhseGetCostValues);
			
			return iMisReceiptItemWhseGetCostValuesExt;
		}
	}
}
