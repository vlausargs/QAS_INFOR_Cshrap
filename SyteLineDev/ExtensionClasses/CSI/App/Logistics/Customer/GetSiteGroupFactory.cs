//PROJECT NAME: Logistics
//CLASS NAME: GetSiteGroupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetSiteGroupFactory
	{
		public IGetSiteGroup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetSiteGroup = new Logistics.Customer.GetSiteGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSiteGroupExt = timerfactory.Create<Logistics.Customer.IGetSiteGroup>(_GetSiteGroup);
			
			return iGetSiteGroupExt;
		}
	}
}
