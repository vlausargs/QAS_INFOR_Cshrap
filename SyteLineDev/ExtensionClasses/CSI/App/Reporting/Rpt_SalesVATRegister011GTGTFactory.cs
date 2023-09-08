//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesVATRegister011GTGTFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SalesVATRegister011GTGTFactory
	{
		public IRpt_SalesVATRegister011GTGT Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalesVATRegister011GTGT = new Reporting.Rpt_SalesVATRegister011GTGT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalesVATRegister011GTGTExt = timerfactory.Create<Reporting.IRpt_SalesVATRegister011GTGT>(_Rpt_SalesVATRegister011GTGT);
			
			return iRpt_SalesVATRegister011GTGTExt;
		}
	}
}
