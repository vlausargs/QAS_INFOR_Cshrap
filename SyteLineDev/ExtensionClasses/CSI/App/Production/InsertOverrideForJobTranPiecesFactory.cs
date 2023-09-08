//PROJECT NAME: Production
//CLASS NAME: InsertOverrideForJobTranPiecesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class InsertOverrideForJobTranPiecesFactory
	{
		public IInsertOverrideForJobTranPieces Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertOverrideForJobTranPieces = new Production.InsertOverrideForJobTranPieces(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertOverrideForJobTranPiecesExt = timerfactory.Create<Production.IInsertOverrideForJobTranPieces>(_InsertOverrideForJobTranPieces);
			
			return iInsertOverrideForJobTranPiecesExt;
		}
	}
}
