//PROJECT NAME: Production
//CLASS NAME: JobtranEmpValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtranEmpValidFactory
	{
		public IJobtranEmpValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtranEmpValid = new Production.JobtranEmpValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranEmpValidExt = timerfactory.Create<Production.IJobtranEmpValid>(_JobtranEmpValid);
			
			return iJobtranEmpValidExt;
		}
	}
}
