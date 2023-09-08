//PROJECT NAME: Production
//CLASS NAME: Home_GetTodaysKeyProductionValuesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class Home_GetTodaysKeyProductionValuesFactory
	{
		public IHome_GetTodaysKeyProductionValues Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _Home_GetTodaysKeyProductionValues = new Production.Home_GetTodaysKeyProductionValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_GetTodaysKeyProductionValuesExt = timerfactory.Create<Production.IHome_GetTodaysKeyProductionValues>(_Home_GetTodaysKeyProductionValues);
			
			return iHome_GetTodaysKeyProductionValuesExt;
		}
	}
}
