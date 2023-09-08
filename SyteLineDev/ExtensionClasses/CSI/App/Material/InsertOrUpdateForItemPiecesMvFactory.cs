//PROJECT NAME: Material
//CLASS NAME: InsertOrUpdateForItemPiecesMvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class InsertOrUpdateForItemPiecesMvFactory
	{
		public IInsertOrUpdateForItemPiecesMv Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertOrUpdateForItemPiecesMv = new Material.InsertOrUpdateForItemPiecesMv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertOrUpdateForItemPiecesMvExt = timerfactory.Create<Material.IInsertOrUpdateForItemPiecesMv>(_InsertOrUpdateForItemPiecesMv);
			
			return iInsertOrUpdateForItemPiecesMvExt;
		}
	}
}
