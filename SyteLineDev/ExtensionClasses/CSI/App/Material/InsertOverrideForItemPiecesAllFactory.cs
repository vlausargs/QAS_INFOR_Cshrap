//PROJECT NAME: Material
//CLASS NAME: InsertOverrideForItemPiecesAllFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class InsertOverrideForItemPiecesAllFactory
	{
		public IInsertOverrideForItemPiecesAll Create(IApplicationDB appDB)
		{
			var _InsertOverrideForItemPiecesAll = new Material.InsertOverrideForItemPiecesAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertOverrideForItemPiecesAllExt = timerfactory.Create<Material.IInsertOverrideForItemPiecesAll>(_InsertOverrideForItemPiecesAll);
			
			return iInsertOverrideForItemPiecesAllExt;
		}
	}
}
