//PROJECT NAME: Production
//CLASS NAME: GetBatchedProdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class GetBatchedProdFactory
	{
		public IGetBatchedProd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetBatchedProd = new Production.GetBatchedProd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetBatchedProdExt = timerfactory.Create<Production.IGetBatchedProd>(_GetBatchedProd);
			
			return iGetBatchedProdExt;
		}
	}
}
