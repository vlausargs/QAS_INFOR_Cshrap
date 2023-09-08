using System;
using System.Collections.Generic;
using System.Text;
using CSI.MG;
using System.Diagnostics.CodeAnalysis;
using CSI.Data;
using CSI.Data.SQL;
using CSI.Data.CRUD;
using CSI.Data.Utilities;
using CSI.CRUD.Logistics.Customer;

namespace CSI.Logistics.Customer
{
    [ExcludeFromCodeCoverage]
    public class GetCustNumFromArtranAllFactory
    {
        public const string IDO = "SLArEftImportArpmtds";
        public const string Method = "GetCustNumFromArtranAllSp";

        public IGetCustNumFromArtranAll Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO, IMessageProvider messageProvider)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            IGetCustNumFromArtranAllCRUD getCustNumFromArtranAllCRUD = new GetCustNumFromArtranAllCRUD(new CollectionLoadRequestFactory(queryLanguage), appDB);
            StringUtil stringUtil = new StringUtil();
            IGetCustNumFromArtranAll iGetCustNumFromArtranAll = new GetCustNumFromArtranAll(messageProvider, getCustNumFromArtranAllCRUD, stringUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                iGetCustNumFromArtranAll = IDOMethodIntercept<IGetCustNumFromArtranAll>.Create(iGetCustNumFromArtranAll, IDO, Method, mgInvoker, interceptConfiguration);
            }


            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCustNumFromArtranAllExt = timerfactory.Create<IGetCustNumFromArtranAll>(iGetCustNumFromArtranAll);

            return iGetCustNumFromArtranAllExt;
        }
    }
}
