//PROJECT NAME: Logistics
//CLASS NAME: ArpmtValidateDraftNumFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtValidateDraftNumFactory
	{
		public IArpmtValidateDraftNum Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtValidateDraftNum = new Logistics.Customer.ArpmtValidateDraftNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtValidateDraftNumExt = timerfactory.Create<Logistics.Customer.IArpmtValidateDraftNum>(_ArpmtValidateDraftNum);
			
			return iArpmtValidateDraftNumExt;
		}
	}
}
