//PROJECT NAME: Production
//CLASS NAME: JobtranitemQtyCompleteValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtranitemQtyCompleteValidFactory
	{
		public IJobtranitemQtyCompleteValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtranitemQtyCompleteValid = new Production.JobtranitemQtyCompleteValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranitemQtyCompleteValidExt = timerfactory.Create<Production.IJobtranitemQtyCompleteValid>(_JobtranitemQtyCompleteValid);
			
			return iJobtranitemQtyCompleteValidExt;
		}
	}
}
