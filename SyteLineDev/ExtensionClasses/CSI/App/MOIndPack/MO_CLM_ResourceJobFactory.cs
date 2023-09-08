//PROJECT NAME: MOIndPack
//CLASS NAME: MO_CLM_ResourceJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.MOIndPack
{
	public class MO_CLM_ResourceJobFactory
	{
		public IMO_CLM_ResourceJob Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _MO_CLM_ResourceJob = new MOIndPack.MO_CLM_ResourceJob(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_CLM_ResourceJobExt = timerfactory.Create<MOIndPack.IMO_CLM_ResourceJob>(_MO_CLM_ResourceJob);
			
			return iMO_CLM_ResourceJobExt;
		}
	}
}
