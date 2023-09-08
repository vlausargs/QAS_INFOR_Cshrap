//PROJECT NAME: Logistics
//CLASS NAME: ProfilePackingSlipFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfilePackingSlipFactory
	{
		public IProfilePackingSlip Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfilePackingSlip = new Logistics.Customer.ProfilePackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfilePackingSlipExt = timerfactory.Create<Logistics.Customer.IProfilePackingSlip>(_ProfilePackingSlip);
			
			return iProfilePackingSlipExt;
		}
	}
}
