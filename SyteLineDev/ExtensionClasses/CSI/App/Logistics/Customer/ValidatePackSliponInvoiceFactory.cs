//PROJECT NAME: Logistics
//CLASS NAME: ValidatePackSliponInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ValidatePackSliponInvoiceFactory
	{
		public IValidatePackSliponInvoice Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidatePackSliponInvoice = new Logistics.Customer.ValidatePackSliponInvoice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidatePackSliponInvoiceExt = timerfactory.Create<Logistics.Customer.IValidatePackSliponInvoice>(_ValidatePackSliponInvoice);
			
			return iValidatePackSliponInvoiceExt;
		}
	}
}
