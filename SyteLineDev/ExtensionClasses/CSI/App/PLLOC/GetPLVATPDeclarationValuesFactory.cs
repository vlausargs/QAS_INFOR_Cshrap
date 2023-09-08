using System;
using System.Collections.Generic;
using System.Text;
using PLLOC.Objects;
using PLLOC.Interfaces;
using CSI.Data.SQL;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Utilities;
using CSI.Data.Functions;
using CSI.Reporting;

namespace CSI.PLLOC
{
    public class GetPLVATPDeclarationValuesFactory
    {
        public const string IDO = "PLVATDeclarations";
        public const string Method = "GetPLVATPDeclarationValues";

        public IJPKV7MDeclarationsManager Create(ICSIExtensionClassBase cSIExtensionClassBase)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            IRptVATManager rptVATManager;
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var rptVATFactory = new RptVATFactory().Create();
            var jPKV7MPurchaseRegisterFactory = new JPKV7MPurchaseRegisterFactory();
            var jPK7MSalesRegisterFactory = new JPK7MSalesRegisterFactory();
            var jPKV7MPurchaseControlFactory = new JPKV7MPurchaseControlFactory();
            var jPKV7MSalesControlFactory = new JPKV7MSalesControlFactory();
            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iHighDate = cSIExtensionClassBase.MongooseDependencies.HighDate;
            var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);

            rptVATManager = new RptVATManager(rptVATFactory, jPKV7MPurchaseRegisterFactory, jPK7MSalesRegisterFactory, jPKV7MPurchaseControlFactory, jPKV7MSalesControlFactory);

            var _Rpt_VAT = new Rpt_VAT(appDB, null, dataTableToCollectionLoadResponse);

            var iCLM_VatProceduralMarkingsCRUD = new CLM_VatProceduralMarkingsCRUD(appDB, collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            var CLM_VatProceduralMarkingsSp = new CLM_VatProceduralMarkingsSp(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                convertToUtil,
                stringUtil,
                iHighDate,
                iLowDate,
                sQLUtil,
                iCLM_VatProceduralMarkingsCRUD);

            var rptVATValuesFromSp = new RptVATValuesFromSp(rptVATManager, appDB, bunchedLoadCollection, new DataTableToCollectionLoadResponse(), _Rpt_VAT, CLM_VatProceduralMarkingsSp, collectionLoadRequestFactory, recordCollectionToDataTable);

            IJPKV7MDeclarationsFactory JPKV7MDeclarationsFactory = new JPKV7MDeclarationsFactory();
            IJPKV7MDeclarationsManager getJPKV7MDeclarations = new JPKV7MDeclarationsManager(appDB, rptVATManager, bunchedLoadCollection, collectionLoadRequestFactory, JPKV7MDeclarationsFactory, rptVATValuesFromSp);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetJPKV7MDeclarations = timerfactory.Create<IJPKV7MDeclarationsManager>(getJPKV7MDeclarations);

            return iGetJPKV7MDeclarations;
        }

        public IJPKV7MDeclarationsManager Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider,
        bool calledFromIDO, IBunchedLoadCollection bunchedLoadCollection)
        {
            IRptVATManager rptVATManager;
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);

            var rptVATFactory = new RptVATFactory().Create();
            var jPKV7MPurchaseRegisterFactory = new JPKV7MPurchaseRegisterFactory();
            var jPK7MSalesRegisterFactory = new JPK7MSalesRegisterFactory();
            var jPKV7MPurchaseControlFactory = new JPKV7MPurchaseControlFactory();
            var jPKV7MSalesControlFactory = new JPKV7MSalesControlFactory();

            rptVATManager = new RptVATManager(rptVATFactory, jPKV7MPurchaseRegisterFactory, jPK7MSalesRegisterFactory, jPKV7MPurchaseControlFactory, jPKV7MSalesControlFactory);

            var _Rpt_VAT = new Rpt_VAT(appDB, null, dataTableToCollectionLoadResponse);

            ICLM_VatProceduralMarkingsSp CLM_VatProceduralMarkingsSp = null; //new CLM_VatProceduralMarkingsSp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
            IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();

            var rptVATValuesFromSp = new RptVATValuesFromSp(rptVATManager, appDB, bunchedLoadCollection, new DataTableToCollectionLoadResponse(), _Rpt_VAT, CLM_VatProceduralMarkingsSp, collectionLoadRequestFactory, recordCollectionToDataTable);

            IJPKV7MDeclarationsFactory JPKV7MDeclarationsFactory = new JPKV7MDeclarationsFactory();
            IJPKV7MDeclarationsManager getJPKV7MDeclarations = new JPKV7MDeclarationsManager(appDB, rptVATManager, bunchedLoadCollection, collectionLoadRequestFactory, JPKV7MDeclarationsFactory, rptVATValuesFromSp);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                getJPKV7MDeclarations = IDOMethodIntercept<IJPKV7MDeclarationsManager>.Create(getJPKV7MDeclarations, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetJPKV7MDeclarations = timerfactory.Create<IJPKV7MDeclarationsManager>(getJPKV7MDeclarations);

            return iGetJPKV7MDeclarations;
        }
    }
}
