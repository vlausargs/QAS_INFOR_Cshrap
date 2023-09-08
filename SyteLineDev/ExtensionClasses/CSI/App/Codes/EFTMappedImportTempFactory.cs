//PROJECT NAME: Codes
//CLASS NAME: EFTMappedImportTempFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class EFTMappedImportTempFactory
	{
		public IEFTMappedImportTemp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EFTMappedImportTemp = new Codes.EFTMappedImportTemp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEFTMappedImportTempExt = timerfactory.Create<Codes.IEFTMappedImportTemp>(_EFTMappedImportTemp);
			
			return iEFTMappedImportTempExt;
		}
	}
}
