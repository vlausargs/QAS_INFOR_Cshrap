//PROJECT NAME: Production
//CLASS NAME: GetSysParPermPlanModeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class GetSysParPermPlanModeFactory
	{
        public IGetSysParPermPlanMode Create(IApplicationDB appDB,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO)
        {
            var _GetSysParPermPlanMode = new Production.Projects.GetSysParPermPlanMode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetSysParPermPlanModeExt = timerfactory.Create<Production.Projects.IGetSysParPermPlanMode>(_GetSysParPermPlanMode);

            return iGetSysParPermPlanModeExt;
        }
        public IGetSysParPermPlanMode Create(ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			
			var _GetSysParPermPlanMode = new Production.Projects.GetSysParPermPlanMode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSysParPermPlanModeExt = timerfactory.Create<Production.Projects.IGetSysParPermPlanMode>(_GetSysParPermPlanMode);
			
			return iGetSysParPermPlanModeExt;
		}
	}
}
