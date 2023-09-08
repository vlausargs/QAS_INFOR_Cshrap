//PROJECT NAME: Logistics
//CLASS NAME: CurrCnvtFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;

namespace CSI.Logistics.Vendor
{
    public class CurrCnvtFactory
    {
        public ICurrCnvt Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
            var _CurrCnvt = new Logistics.Vendor.CurrCnvt(appDB, dataTableToCollectionLoadResponse, dataTableUtil);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCurrCnvtExt = timerfactory.Create<Logistics.Vendor.ICurrCnvt>(_CurrCnvt);

            return iCurrCnvtExt;
        }

        public ICurrCnvt Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
            var _CurrCnvt = new Logistics.Vendor.CurrCnvt(appDB, dataTableToCollectionLoadResponse, dataTableUtil);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCurrCnvtExt = timerfactory.Create<ICurrCnvt>(_CurrCnvt);

            return iCurrCnvtExt;
        }
    }
}
