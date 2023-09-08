//PROJECT NAME: DataCollection
//CLASS NAME: DcSfcLoadWcFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.DataCollection
{
	public class DcSfcLoadWcFactory
	{
		public IDcSfcLoadWc Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DcSfcLoadWc = new DataCollection.DcSfcLoadWc(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDcSfcLoadWcExt = timerfactory.Create<DataCollection.IDcSfcLoadWc>(_DcSfcLoadWc);
			
			return iDcSfcLoadWcExt;
		}
	}
}
