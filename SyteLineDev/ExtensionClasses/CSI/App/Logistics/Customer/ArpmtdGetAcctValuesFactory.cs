//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdGetAcctValuesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtdGetAcctValuesFactory
	{
		public IArpmtdGetAcctValues Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtdGetAcctValues = new Logistics.Customer.ArpmtdGetAcctValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtdGetAcctValuesExt = timerfactory.Create<Logistics.Customer.IArpmtdGetAcctValues>(_ArpmtdGetAcctValues);
			
			return iArpmtdGetAcctValuesExt;
		}
	}
}
