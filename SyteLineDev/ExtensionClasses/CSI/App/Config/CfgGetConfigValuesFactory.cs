//PROJECT NAME: Data
//CLASS NAME: CfgGetConfigValuesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Config
{
    public class CfgGetConfigValuesFactory
    {
        public ICfgGetConfigValues Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);

            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _CfgGetConfigValues = new CfgGetConfigValues(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse, dataTableUtil);


            return _CfgGetConfigValues;
        }
    }
}
