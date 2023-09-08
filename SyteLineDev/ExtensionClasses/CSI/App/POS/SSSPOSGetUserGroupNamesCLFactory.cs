//PROJECT NAME: POS
//CLASS NAME: SSSPOSGetUserGroupNamesCLFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.POS
{
	public class SSSPOSGetUserGroupNamesCLFactory
	{
		public ISSSPOSGetUserGroupNamesCL Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSPOSGetUserGroupNamesCL = new POS.SSSPOSGetUserGroupNamesCL(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSGetUserGroupNamesCLExt = timerfactory.Create<POS.ISSSPOSGetUserGroupNamesCL>(_SSSPOSGetUserGroupNamesCL);
			
			return iSSSPOSGetUserGroupNamesCLExt;
		}
	}
}
