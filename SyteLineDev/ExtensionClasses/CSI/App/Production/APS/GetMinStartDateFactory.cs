//PROJECT NAME: Production
//CLASS NAME: GetMinStartDateFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;

namespace CSI.Production.APS
{
    public class GetMinStartDateFactory
    {
        public const string IDO = "ResourceSchedules";
        public const string Method = "GetMinStartDate";

        public IGetMinStartDate Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IGetMinStartDate _GetMinStartDate = new GetMinStartDate(appDB,
                collectionLoadRequestFactory,
                scalarFunction,
                convertToUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _GetMinStartDate = IDOMethodIntercept<IGetMinStartDate>.Create(_GetMinStartDate, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetMinStartDateExt = timerfactory.Create<IGetMinStartDate>(_GetMinStartDate);

            return iGetMinStartDateExt;
        }
    }
}
