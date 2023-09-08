//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemwhseCheckCntInProcFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemwhseCheckCntInProcFactory
	{
		public IItemwhseCheckCntInProc Create(IApplicationDB appDB)
		{
			var _ItemwhseCheckCntInProc = new Material.ItemwhseCheckCntInProc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemwhseCheckCntInProcExt = timerfactory.Create<Material.IItemwhseCheckCntInProc>(_ItemwhseCheckCntInProc);
			
			return iItemwhseCheckCntInProcExt;
		}
	}
}
