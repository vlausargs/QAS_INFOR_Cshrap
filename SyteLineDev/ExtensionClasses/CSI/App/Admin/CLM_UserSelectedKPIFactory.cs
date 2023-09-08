//PROJECT NAME: Admin
//CLASS NAME: CLM_UserSelectedKPIFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_UserSelectedKPIFactory
	{
		public ICLM_UserSelectedKPI Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_UserSelectedKPI = new Admin.CLM_UserSelectedKPI(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_UserSelectedKPIExt = timerfactory.Create<Admin.ICLM_UserSelectedKPI>(_CLM_UserSelectedKPI);
			
			return iCLM_UserSelectedKPIExt;
		}
	}
}
