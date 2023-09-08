//PROJECT NAME: Production
//CLASS NAME: GenUnpostedJobTransForBatchedProdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class GenUnpostedJobTransForBatchedProdFactory
	{
		public IGenUnpostedJobTransForBatchedProd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GenUnpostedJobTransForBatchedProd = new Production.GenUnpostedJobTransForBatchedProd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenUnpostedJobTransForBatchedProdExt = timerfactory.Create<Production.IGenUnpostedJobTransForBatchedProd>(_GenUnpostedJobTransForBatchedProd);
			
			return iGenUnpostedJobTransForBatchedProdExt;
		}
	}
}
