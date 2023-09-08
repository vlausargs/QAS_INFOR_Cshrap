//PROJECT NAME: Finance
//CLASS NAME: FRCLM_FecExportFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class FRCLM_FecExportFactory
	{
		public IFRCLM_FecExport Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FRCLM_FecExport = new Finance.FRCLM_FecExport(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFRCLM_FecExportExt = timerfactory.Create<Finance.IFRCLM_FecExport>(_FRCLM_FecExport);
			
			return iFRCLM_FecExportExt;
		}
	}
}
