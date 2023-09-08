//PROJECT NAME: Logistics
//CLASS NAME: EdiPoAckValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class EdiPoAckValidateFactory
	{
		public IEdiPoAckValidate Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EdiPoAckValidate = new Logistics.Vendor.EdiPoAckValidate(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEdiPoAckValidateExt = timerfactory.Create<Logistics.Vendor.IEdiPoAckValidate>(_EdiPoAckValidate);
			
			return iEdiPoAckValidateExt;
		}
	}
}
