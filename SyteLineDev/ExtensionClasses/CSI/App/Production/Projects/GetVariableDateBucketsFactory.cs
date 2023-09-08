//PROJECT NAME: Production
//CLASS NAME: GetVariableDateBucketsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class GetVariableDateBucketsFactory
	{
		public IGetVariableDateBuckets Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetVariableDateBuckets = new Production.Projects.GetVariableDateBuckets(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVariableDateBucketsExt = timerfactory.Create<Production.Projects.IGetVariableDateBuckets>(_GetVariableDateBuckets);
			
			return iGetVariableDateBucketsExt;
		}
	}
}
