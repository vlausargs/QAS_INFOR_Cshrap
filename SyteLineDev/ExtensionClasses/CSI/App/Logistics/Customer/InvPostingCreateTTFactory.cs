//PROJECT NAME: Logistics
//CLASS NAME: InvPostingCreateTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class InvPostingCreateTTFactory
	{
		public IInvPostingCreateTT Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _InvPostingCreateTT = new Logistics.Customer.InvPostingCreateTT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInvPostingCreateTTExt = timerfactory.Create<Logistics.Customer.IInvPostingCreateTT>(_InvPostingCreateTT);
			
			return iInvPostingCreateTTExt;
		}
	}
}
