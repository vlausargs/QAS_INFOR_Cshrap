//PROJECT NAME: Finance
//CLASS NAME: InitPeriodsTableFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class InitPeriodsTableFactory
	{
		public IInitPeriodsTable Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InitPeriodsTable = new Finance.InitPeriodsTable(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInitPeriodsTableExt = timerfactory.Create<Finance.IInitPeriodsTable>(_InitPeriodsTable);
			
			return iInitPeriodsTableExt;
		}
	}
}
