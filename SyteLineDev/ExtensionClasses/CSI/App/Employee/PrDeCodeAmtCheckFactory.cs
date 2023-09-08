//PROJECT NAME: Employee
//CLASS NAME: PrDeCodeAmtCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PrDeCodeAmtCheckFactory
	{
		public IPrDeCodeAmtCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PrDeCodeAmtCheck = new Employee.PrDeCodeAmtCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrDeCodeAmtCheckExt = timerfactory.Create<Employee.IPrDeCodeAmtCheck>(_PrDeCodeAmtCheck);
			
			return iPrDeCodeAmtCheckExt;
		}
	}
}
