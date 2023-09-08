//PROJECT NAME: Material
//CLASS NAME: GetMaxSerialNumSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetMaxSerialNumSiteFactory
	{
		public IGetMaxSerialNumSite Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetMaxSerialNumSite = new Material.GetMaxSerialNumSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMaxSerialNumSiteExt = timerfactory.Create<Material.IGetMaxSerialNumSite>(_GetMaxSerialNumSite);
			
			return iGetMaxSerialNumSiteExt;
		}
	}
}
