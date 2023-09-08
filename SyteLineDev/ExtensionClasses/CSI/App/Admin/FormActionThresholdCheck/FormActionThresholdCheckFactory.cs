using CSI.Data;
using CSI.Data.SQL;
using CSI.MG;
using System.Diagnostics.CodeAnalysis;
using CSI.CRUD.Admin.FormActionThresholdCheck;
using CSI.Data.CRUD;
using CSI.MG.MGCore;

namespace CSI.Admin.FormActionThresholdCheck
{
    [ExcludeFromCodeCoverage]
    public class FormActionThresholdCheckFactory
    {
        public const string IDO = "SLFormActionThresholds";
        public const string Method = "GetPrintProcessRecountCount";

        public IFormActionThresholdCheck Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO, IMessageProvider messageProvider, IUserName userName)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            IFormActionThresholdCRUD formActionThresholdCRUD = new FormActionThresholdCRUD(new CollectionLoadRequestFactory(queryLanguage), appDB);
            IFormActionThresholdCheck iGetPrintProcessRecountCount = new FormActionThresholdCheck(messageProvider, formActionThresholdCRUD, userName);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                iGetPrintProcessRecountCount = IDOMethodIntercept<IFormActionThresholdCheck>.Create(iGetPrintProcessRecountCount, IDO, Method, mgInvoker, interceptConfiguration);
            }


            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetPrintProcessRecountCountExt = timerfactory.Create<IFormActionThresholdCheck>(iGetPrintProcessRecountCount);

            return iGetPrintProcessRecountCountExt;
        }
    }
}
