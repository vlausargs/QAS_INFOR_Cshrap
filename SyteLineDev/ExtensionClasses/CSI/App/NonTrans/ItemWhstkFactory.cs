//PROJECT NAME: NonTrans
//CLASS NAME: ItemWhstkFactory.cs

using CSI.MG;

namespace CSI.NonTrans
{
	public class ItemWhstkFactory
	{
		public IItemWhstk Create(IApplicationDB appDB)
		{
			var _ItemWhstk = new NonTrans.ItemWhstk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemWhstkExt = timerfactory.Create<NonTrans.IItemWhstk>(_ItemWhstk);
			
			return iItemWhstkExt;
		}
	}
}
