//PROJECT NAME: Production
//CLASS NAME: GetJobmatlSeqListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class GetJobmatlSeqListFactory
	{
		public IGetJobmatlSeqList Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _GetJobmatlSeqList = new Production.GetJobmatlSeqList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetJobmatlSeqListExt = timerfactory.Create<Production.IGetJobmatlSeqList>(_GetJobmatlSeqList);
			
			return iGetJobmatlSeqListExt;
		}
	}
}
