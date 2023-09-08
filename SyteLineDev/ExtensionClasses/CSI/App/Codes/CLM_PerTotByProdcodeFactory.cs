//PROJECT NAME: Codes
//CLASS NAME: CLM_PerTotByProdcodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
    public class CLM_PerTotByProdcodeFactory
    {
        public ICLM_PerTotByProdcode Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CLM_PerTotByProdcode = new Codes.CLM_PerTotByProdcode(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_PerTotByProdcodeExt = timerfactory.Create<Codes.ICLM_PerTotByProdcode>(_CLM_PerTotByProdcode);

            return iCLM_PerTotByProdcodeExt;
        }
    }
}
