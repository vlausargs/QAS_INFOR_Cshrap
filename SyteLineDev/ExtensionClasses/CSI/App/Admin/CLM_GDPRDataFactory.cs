//PROJECT NAME: Admin
//CLASS NAME: CLM_GDPRDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CLM_GDPRDataFactory
	{
		public ICLM_GDPRData Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GDPRData = new Admin.CLM_GDPRData(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GDPRDataExt = timerfactory.Create<Admin.ICLM_GDPRData>(_CLM_GDPRData);
			
			return iCLM_GDPRDataExt;
		}
	}
}
