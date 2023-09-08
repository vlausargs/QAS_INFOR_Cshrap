using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.Functions;
using CSI.Data.RecordSets;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.MG.IDM;
using CSI.MXLOC.Interfaces;
using CSI.MXLOC.Objects;
using System;
using System.Collections.Generic;
using System.Text;


namespace CSI.MXLOC
{
    public class ApprovedXMLFactory
    {
        public const string IDO = "SLElectronicInvs";
        public const string Method = "ProcessApprovedXML";

        public IApprovedXML Create(ICSIExtensionClassBase cSIExtensionClassBase,
        IIDM iDM,
        bool calledFromIDO)
        {

            var scalarFunction = new ScalarFunctionFactory().Create(cSIExtensionClassBase.AppDB, cSIExtensionClassBase.ParameterProvider);
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var queryLanguage = new SQLQueryLanguageFactory().Create(cSIExtensionClassBase.ParameterProvider);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var recordCollectionToDataTable = new RecordCollectionToDataTable();
            var dateTimeUtil = new DateTimeUtil(new DataTypeUtil());
            IMsgApp msgApp = new MsgApp(cSIExtensionClassBase.AppDB);

            MXElectronicInvFactory mXElectronicInvFactory = new MXElectronicInvFactory();
            IApprovedXMLCRUD approvedXMLCRUD = new ApprovedXMLCRUD(collectionLoadRequestFactory, cSIExtensionClassBase.AppDB, collectionUpdateRequestFactory, recordCollectionToDataTable);

            IApprovedXML _ApprovedXML = new ApprovedXML(iDM, msgApp, mXElectronicInvFactory, approvedXMLCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ApprovedXML = IDOMethodIntercept<IApprovedXML>.Create(_ApprovedXML, IDO, Method, cSIExtensionClassBase.MGInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iApprovedXMLExt = timerfactory.Create<IApprovedXML>(_ApprovedXML);

            return iApprovedXMLExt;
        }
    }
}
