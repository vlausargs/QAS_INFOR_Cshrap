//PROJECT NAME: Production
//CLASS NAME: PmfFmGetOperationsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmGetOperationsFactory
	{
		public IPmfFmGetOperations Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfFmGetOperations = new Production.ProcessManufacturing.PmfFmGetOperations(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmGetOperationsExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmGetOperations>(_PmfFmGetOperations);
			
			return iPmfFmGetOperationsExt;
		}
	}
}
