//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdChgInvNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtdChgInvNumFactory
	{
		public IArpmtdChgInvNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtdChgInvNum = new Logistics.Customer.ArpmtdChgInvNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdChgInvNumExt = timerfactory.Create<Logistics.Customer.IArpmtdChgInvNum>(_ArpmtdChgInvNum);
			
			return iArpmtdChgInvNumExt;
		}
	}
}
