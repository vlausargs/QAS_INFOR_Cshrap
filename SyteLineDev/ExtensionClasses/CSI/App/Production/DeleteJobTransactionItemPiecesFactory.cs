//PROJECT NAME: Production
//CLASS NAME: DeleteJobTransactionItemPiecesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class DeleteJobTransactionItemPiecesFactory
	{
		public IDeleteJobTransactionItemPieces Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteJobTransactionItemPieces = new Production.DeleteJobTransactionItemPieces(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteJobTransactionItemPiecesExt = timerfactory.Create<Production.IDeleteJobTransactionItemPieces>(_DeleteJobTransactionItemPieces);
			
			return iDeleteJobTransactionItemPiecesExt;
		}
	}
}
