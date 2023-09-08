//PROJECT NAME: Logistics
//CLASS NAME: CoBlnPostQueryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoBlnPostQueryFactory
	{
		public ICoBlnPostQuery Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoBlnPostQuery = new Logistics.Customer.CoBlnPostQuery(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoBlnPostQueryExt = timerfactory.Create<Logistics.Customer.ICoBlnPostQuery>(_CoBlnPostQuery);
			
			return iCoBlnPostQueryExt;
		}
	}
}
