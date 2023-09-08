//PROJECT NAME: Employee
//CLASS NAME: InsCalcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class InsCalcFactory
	{
		public IInsCalc Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _InsCalc = new Employee.InsCalc(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsCalcExt = timerfactory.Create<Employee.IInsCalc>(_InsCalc);

			return iInsCalcExt;
		}
	}
}
