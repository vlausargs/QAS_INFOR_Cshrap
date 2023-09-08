//PROJECT NAME: Finance.AR
//CLASS NAME: ARAgingBucketsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.AR
{
	public class ARAgingBucketsFactory : IARAgingBucketsFactory
	{
		public IARAgingBuckets Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARAgingBuckets = new Finance.AR.ARAgingBuckets(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARAgingBucketsExt = timerfactory.Create<Finance.AR.IARAgingBuckets>(_ARAgingBuckets);

			return iARAgingBucketsExt;
		}
	}
}
