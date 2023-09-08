//PROJECT NAME: Production
//CLASS NAME: SaveBomIBJobrouteFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class SaveBomIBJobrouteFactory
	{
		public ISaveBomIBJobroute Create(IApplicationDB appDB)
		{
			var _SaveBomIBJobroute = new Production.SaveBomIBJobroute(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveBomIBJobrouteExt = timerfactory.Create<Production.ISaveBomIBJobroute>(_SaveBomIBJobroute);
			
			return iSaveBomIBJobrouteExt;
		}
	}
}
