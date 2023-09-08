//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSchedProfilesFiltersSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.FieldService.Partner
{
	public class SSSFSSchedProfilesFiltersSaveFactory
	{
		public ISSSFSSchedProfilesFiltersSave Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var _SSSFSSchedProfilesFiltersSave = new Logistics.FieldService.Partner.SSSFSSchedProfilesFiltersSave(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSSchedProfilesFiltersSaveExt = timerfactory.Create<Logistics.FieldService.Partner.ISSSFSSchedProfilesFiltersSave>(_SSSFSSchedProfilesFiltersSave);

			return iSSSFSSchedProfilesFiltersSaveExt;
		}
	}
}
