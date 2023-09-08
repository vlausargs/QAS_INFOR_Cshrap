//PROJECT NAME: Logistics
//CLASS NAME: PackageLoadTreeLevelFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class PackageLoadTreeLevelFactory
	{
		public IPackageLoadTreeLevel Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PackageLoadTreeLevel = new Logistics.Customer.PackageLoadTreeLevel(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPackageLoadTreeLevelExt = timerfactory.Create<Logistics.Customer.IPackageLoadTreeLevel>(_PackageLoadTreeLevel);
			
			return iPackageLoadTreeLevelExt;
		}
	}
}
