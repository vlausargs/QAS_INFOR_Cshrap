//PROJECT NAME: Logistics
//CLASS NAME: GetLogicalFoldersByPermissionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class GetLogicalFoldersByPermissionFactory
	{
		public IGetLogicalFoldersByPermission Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _GetLogicalFoldersByPermission = new Logistics.Vendor.GetLogicalFoldersByPermission(appDB, bunchedLoadCollection,dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetLogicalFoldersByPermissionExt = timerfactory.Create<Logistics.Vendor.IGetLogicalFoldersByPermission>(_GetLogicalFoldersByPermission);
			
			return iGetLogicalFoldersByPermissionExt;
		}
	}
}
