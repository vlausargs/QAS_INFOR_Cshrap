//PROJECT NAME: Logistics
//CLASS NAME: SchedUpdatePartnerFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedUpdatePartnerFactory
	{
		public ISchedUpdatePartner Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SchedUpdatePartner = new Logistics.FieldService.Partner.SchedUpdatePartner(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedUpdatePartnerExt = timerfactory.Create<Logistics.FieldService.Partner.ISchedUpdatePartner>(_SchedUpdatePartner);
			
			return iSchedUpdatePartnerExt;
		}
	}
}
