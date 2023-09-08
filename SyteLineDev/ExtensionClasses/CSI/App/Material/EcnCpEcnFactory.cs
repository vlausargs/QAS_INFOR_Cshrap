//PROJECT NAME: Material
//CLASS NAME: EcnCpEcnFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class EcnCpEcnFactory
	{
		public IEcnCpEcn Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EcnCpEcn = new Material.EcnCpEcn(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEcnCpEcnExt = timerfactory.Create<Material.IEcnCpEcn>(_EcnCpEcn);
			
			return iEcnCpEcnExt;
		}
	}
}
