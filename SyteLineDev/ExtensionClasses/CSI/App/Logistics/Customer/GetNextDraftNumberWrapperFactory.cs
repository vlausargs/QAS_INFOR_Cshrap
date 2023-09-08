//PROJECT NAME: Logistics
//CLASS NAME: GetNextDraftNumberWrapperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetNextDraftNumberWrapperFactory
	{
		public IGetNextDraftNumberWrapper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextDraftNumberWrapper = new Logistics.Customer.GetNextDraftNumberWrapper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextDraftNumberWrapperExt = timerfactory.Create<Logistics.Customer.IGetNextDraftNumberWrapper>(_GetNextDraftNumberWrapper);
			
			return iGetNextDraftNumberWrapperExt;
		}
	}
}
