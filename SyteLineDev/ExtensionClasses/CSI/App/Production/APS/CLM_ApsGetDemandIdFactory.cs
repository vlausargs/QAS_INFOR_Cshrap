//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetDemandIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
    public class CLM_ApsGetDemandIdFactory
    {
        public ICLM_ApsGetDemandId Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CLM_ApsGetDemandId = new Production.APS.CLM_ApsGetDemandId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetDemandIdExt = timerfactory.Create<Production.APS.ICLM_ApsGetDemandId>(_CLM_ApsGetDemandId);

            return iCLM_ApsGetDemandIdExt;
        }

        public ICLM_ApsGetDemandId Create(ICSIExtensionClassBase cSIExtensionClassBase,
        bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CLM_ApsGetDemandId = new Production.APS.CLM_ApsGetDemandId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetDemandIdExt = timerfactory.Create<Production.APS.ICLM_ApsGetDemandId>(_CLM_ApsGetDemandId);

            return iCLM_ApsGetDemandIdExt;
        }
    }
}