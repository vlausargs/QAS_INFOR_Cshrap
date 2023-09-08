using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.MG.IDM;
using CSI.MXLOC.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.MXLOC
{
    public class CFDIReceiptFactory
    {
        public const string IDO = "SLMXElectronicPaymentReceipts";
        public const string Method = "ProcessCFDIReceipt";

        public ICFDIReceipt Create(ICSIExtensionClassBase cSIExtensionClassBase,
        IIDM iDM,
        bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(cSIExtensionClassBase.ParameterProvider);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var recordCollectionToDataTable = new RecordCollectionToDataTable();
            IMsgApp msgApp = new MsgApp(cSIExtensionClassBase.AppDB);

            MXElectronicPaymentReceiptFactory mXElectronicPaymentReceiptFactory = new MXElectronicPaymentReceiptFactory();
            MXElectronicPaymentReceiptDetailFactory mXElectronicPaymentReceiptDetailFactory = new MXElectronicPaymentReceiptDetailFactory();
            ICFDIReceiptCRUD cFDIReceiptCRUD = new CFDIReceiptCRUD(collectionLoadRequestFactory, cSIExtensionClassBase.AppDB, collectionUpdateRequestFactory, recordCollectionToDataTable);

            ICFDIReceipt _CFDIReceipt = new CFDIReceipt(iDM, msgApp, mXElectronicPaymentReceiptFactory, mXElectronicPaymentReceiptDetailFactory, cFDIReceiptCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CFDIReceipt = IDOMethodIntercept<ICFDIReceipt>.Create(_CFDIReceipt, IDO, Method, cSIExtensionClassBase.MGInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCFDIReceiptLExt = timerfactory.Create<ICFDIReceipt>(_CFDIReceipt);

            return iCFDIReceiptLExt;
        }
    }
}
