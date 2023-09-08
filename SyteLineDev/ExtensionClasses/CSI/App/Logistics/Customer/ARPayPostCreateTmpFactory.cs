//PROJECT NAME: Logistics
//CLASS NAME: ARPayPostCreateTmpFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ARPayPostCreateTmpFactory
	{
		public IARPayPostCreateTmp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ARPayPostCreateTmp = new Logistics.Customer.ARPayPostCreateTmp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPayPostCreateTmpExt = timerfactory.Create<Logistics.Customer.IARPayPostCreateTmp>(_ARPayPostCreateTmp);
			
			return iARPayPostCreateTmpExt;
		}
	}
}
