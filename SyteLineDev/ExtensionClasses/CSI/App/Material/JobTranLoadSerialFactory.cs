//PROJECT NAME: Material
//CLASS NAME: JobTranLoadSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class JobTranLoadSerialFactory
	{
		public IJobTranLoadSerial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _JobTranLoadSerial = new Material.JobTranLoadSerial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobTranLoadSerialExt = timerfactory.Create<Material.IJobTranLoadSerial>(_JobTranLoadSerial);
			
			return iJobTranLoadSerialExt;
		}
	}
}
