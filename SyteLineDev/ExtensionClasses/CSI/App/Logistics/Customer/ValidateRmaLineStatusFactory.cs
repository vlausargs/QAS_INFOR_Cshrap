//PROJECT NAME: Logistics
//CLASS NAME: ValidateRmaLineStatusFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
	public class ValidateRmaLineStatusFactory
	{
		public const string IDO = "SLRmaitems";
		public const string Method = "ValidateRmaLineStatus";

		public IValidateRmaLineStatus Create(IApplicationDB appDB,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);

			IValidateRmaLineStatus _ValidateRmaLineStatus = new ValidateRmaLineStatus(appDB,
				collectionLoadRequestFactory,
				stringUtil,
				sQLUtil,
				iMsgApp);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ValidateRmaLineStatus = IDOMethodIntercept<IValidateRmaLineStatus>.Create(_ValidateRmaLineStatus, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateRmaLineStatusExt = timerfactory.Create<IValidateRmaLineStatus>(_ValidateRmaLineStatus);

			return iValidateRmaLineStatusExt;
		}
	}
}
