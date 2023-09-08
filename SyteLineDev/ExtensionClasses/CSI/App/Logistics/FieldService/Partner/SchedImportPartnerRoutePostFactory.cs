//PROJECT NAME: Logistics
//CLASS NAME: SchedImportPartnerRoutePostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedImportPartnerRoutePostFactory
	{
		public ISchedImportPartnerRoutePost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SchedImportPartnerRoutePost = new Logistics.FieldService.Partner.SchedImportPartnerRoutePost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedImportPartnerRoutePostExt = timerfactory.Create<Logistics.FieldService.Partner.ISchedImportPartnerRoutePost>(_SchedImportPartnerRoutePost);
			
			return iSchedImportPartnerRoutePostExt;
		}
	}
}
