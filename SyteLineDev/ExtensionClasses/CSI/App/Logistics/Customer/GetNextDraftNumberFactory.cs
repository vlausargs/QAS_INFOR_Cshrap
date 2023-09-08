//PROJECT NAME: Logistics
//CLASS NAME: GetNextDraftNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetNextDraftNumberFactory
	{
		public IGetNextDraftNumber Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextDraftNumber = new Logistics.Customer.GetNextDraftNumber(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextDraftNumberExt = timerfactory.Create<Logistics.Customer.IGetNextDraftNumber>(_GetNextDraftNumber);
			
			return iGetNextDraftNumberExt;
		}
	}
}
