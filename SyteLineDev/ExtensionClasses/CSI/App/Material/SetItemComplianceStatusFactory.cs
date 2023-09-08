//PROJECT NAME: Material
//CLASS NAME: SetItemComplianceStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class SetItemComplianceStatusFactory
	{
		public ISetItemComplianceStatus Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SetItemComplianceStatus = new Material.SetItemComplianceStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetItemComplianceStatusExt = timerfactory.Create<Material.ISetItemComplianceStatus>(_SetItemComplianceStatus);
			
			return iSetItemComplianceStatusExt;
		}

        public ISetItemComplianceStatus Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var _SetItemComplianceStatus = new Material.SetItemComplianceStatus(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSetItemComplianceStatusExt = timerfactory.Create<Material.ISetItemComplianceStatus>(_SetItemComplianceStatus);

            return iSetItemComplianceStatusExt;
        }
    }
}
