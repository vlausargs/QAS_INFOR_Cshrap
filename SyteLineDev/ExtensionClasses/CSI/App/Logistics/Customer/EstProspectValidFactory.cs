//PROJECT NAME: Logistics
//CLASS NAME: EstProspectValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstProspectValidFactory
	{
		public IEstProspectValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstProspectValid = new Logistics.Customer.EstProspectValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstProspectValidExt = timerfactory.Create<Logistics.Customer.IEstProspectValid>(_EstProspectValid);
			
			return iEstProspectValidExt;
		}
	}
}
