//PROJECT NAME: CSICodes
//CLASS NAME: InventoryBalLabelsFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class InventoryBalLabelsFactory
	{
		public IInventoryBalLabels Create(IApplicationDB appDB)
		{
			var _InventoryBalLabels = new Codes.InventoryBalLabels(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInventoryBalLabelsExt = timerfactory.Create<Codes.IInventoryBalLabels>(_InventoryBalLabels);
			
			return iInventoryBalLabelsExt;
		}
	}
}
