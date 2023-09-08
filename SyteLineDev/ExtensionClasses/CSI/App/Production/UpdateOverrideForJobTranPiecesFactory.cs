//PROJECT NAME: Production
//CLASS NAME: UpdateOverrideForJobTranPiecesFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class UpdateOverrideForJobTranPiecesFactory
	{
		public IUpdateOverrideForJobTranPieces Create(IApplicationDB appDB)
		{
			var _UpdateOverrideForJobTranPieces = new Production.UpdateOverrideForJobTranPieces(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateOverrideForJobTranPiecesExt = timerfactory.Create<Production.IUpdateOverrideForJobTranPieces>(_UpdateOverrideForJobTranPieces);
			
			return iUpdateOverrideForJobTranPiecesExt;
		}
	}
}
