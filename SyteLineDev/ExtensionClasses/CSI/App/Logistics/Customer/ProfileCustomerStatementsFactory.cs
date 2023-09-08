//PROJECT NAME: Logistics
//CLASS NAME: ProfileCustomerStatementsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileCustomerStatementsFactory
	{
		public IProfileCustomerStatements Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileCustomerStatements = new Logistics.Customer.ProfileCustomerStatements(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileCustomerStatementsExt = timerfactory.Create<Logistics.Customer.IProfileCustomerStatements>(_ProfileCustomerStatements);
			
			return iProfileCustomerStatementsExt;
		}
	}
}
