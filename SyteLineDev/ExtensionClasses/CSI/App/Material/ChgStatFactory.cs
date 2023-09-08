//PROJECT NAME: CSIMaterial
//CLASS NAME: ChgStatFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ChgStatFactory
	{
		public IChgStat Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ChgStat = new Material.ChgStat(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChgStatExt = timerfactory.Create<Material.IChgStat>(_ChgStat);
			
			return iChgStatExt;
		}
	}
}
