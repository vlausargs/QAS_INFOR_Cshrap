//PROJECT NAME: Material
//CLASS NAME: GetInvSiteGrpFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetInvSiteGrpFactory
	{
		public IGetInvSiteGrp Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetInvSiteGrp = new Material.GetInvSiteGrp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInvSiteGrpExt = timerfactory.Create<Material.IGetInvSiteGrp>(_GetInvSiteGrp);
			
			return iGetInvSiteGrpExt;
		}
        public IGetInvSiteGrp Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _GetInvSiteGrp = new Material.GetInvSiteGrp(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetInvSiteGrpExt = timerfactory.Create<Material.IGetInvSiteGrp>(_GetInvSiteGrp);

            return iGetInvSiteGrpExt;
        }
    }
}
