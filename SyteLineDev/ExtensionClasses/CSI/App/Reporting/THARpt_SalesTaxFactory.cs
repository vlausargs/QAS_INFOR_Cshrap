//PROJECT NAME: Reporting
//CLASS NAME: THARpt_SalesTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class THARpt_SalesTaxFactory
	{
		public ITHARpt_SalesTax Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _THARpt_SalesTax = new Reporting.THARpt_SalesTax(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHARpt_SalesTaxExt = timerfactory.Create<Reporting.ITHARpt_SalesTax>(_THARpt_SalesTax);
			
			return iTHARpt_SalesTaxExt;
		}
	}
}
