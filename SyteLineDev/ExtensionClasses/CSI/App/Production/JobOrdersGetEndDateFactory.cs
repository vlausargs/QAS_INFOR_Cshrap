//PROJECT NAME: Production
//CLASS NAME: JobOrdersGetEndDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobOrdersGetEndDateFactory
	{
		public IJobOrdersGetEndDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobOrdersGetEndDate = new Production.JobOrdersGetEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobOrdersGetEndDateExt = timerfactory.Create<Production.IJobOrdersGetEndDate>(_JobOrdersGetEndDate);
			
			return iJobOrdersGetEndDateExt;
		}
	}
}
