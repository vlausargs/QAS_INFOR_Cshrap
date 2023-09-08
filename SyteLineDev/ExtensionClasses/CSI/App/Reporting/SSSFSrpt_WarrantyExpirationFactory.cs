//PROJECT NAME: Reporting
//CLASS NAME: SSSFSrpt_WarrantyExpirationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSrpt_WarrantyExpirationFactory
	{
		public ISSSFSrpt_WarrantyExpiration Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSrpt_WarrantyExpiration = new Reporting.SSSFSrpt_WarrantyExpiration(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSrpt_WarrantyExpirationExt = timerfactory.Create<Reporting.ISSSFSrpt_WarrantyExpiration>(_SSSFSrpt_WarrantyExpiration);
			
			return iSSSFSrpt_WarrantyExpirationExt;
		}
	}
}
