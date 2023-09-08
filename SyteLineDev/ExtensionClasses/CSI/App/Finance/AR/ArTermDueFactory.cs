//PROJECT NAME: Data
//CLASS NAME: ArTermDueFactory.cs

using CSI.MG;
using CSI.Data.Utilities;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Finance.AR
{
    public class ArTermDueFactory
    {
        public IArTermDue Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);

            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _ArTermDue = new ArTermDue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse, dataTableUtil);

            return _ArTermDue;
        }
    }
}
