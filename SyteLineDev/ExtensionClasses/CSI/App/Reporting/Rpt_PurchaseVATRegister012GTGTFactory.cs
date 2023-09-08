//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseVATRegister012GTGTFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchaseVATRegister012GTGTFactory
	{
		public IRpt_PurchaseVATRegister012GTGT Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchaseVATRegister012GTGT = new Reporting.Rpt_PurchaseVATRegister012GTGT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchaseVATRegister012GTGTExt = timerfactory.Create<Reporting.IRpt_PurchaseVATRegister012GTGT>(_Rpt_PurchaseVATRegister012GTGT);
			
			return iRpt_PurchaseVATRegister012GTGTExt;
		}
	}
}
