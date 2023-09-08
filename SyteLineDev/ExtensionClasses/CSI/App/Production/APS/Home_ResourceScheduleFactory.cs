//PROJECT NAME: Production
//CLASS NAME: Home_ResourceScheduleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class Home_ResourceScheduleFactory
	{
		public IHome_ResourceSchedule Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_ResourceSchedule = new Production.APS.Home_ResourceSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_ResourceScheduleExt = timerfactory.Create<Production.APS.IHome_ResourceSchedule>(_Home_ResourceSchedule);
			
			return iHome_ResourceScheduleExt;
		}
	}
}
