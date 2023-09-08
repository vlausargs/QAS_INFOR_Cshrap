//PROJECT NAME: Production
//CLASS NAME: JobOrdersValidateItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobOrdersValidateItemFactory
	{
		public IJobOrdersValidateItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobOrdersValidateItem = new Production.JobOrdersValidateItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobOrdersValidateItemExt = timerfactory.Create<Production.IJobOrdersValidateItem>(_JobOrdersValidateItem);
			
			return iJobOrdersValidateItemExt;
		}
	}
}
