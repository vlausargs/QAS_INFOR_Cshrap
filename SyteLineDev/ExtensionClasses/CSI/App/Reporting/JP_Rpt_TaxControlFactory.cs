//PROJECT NAME: Reporting
//CLASS NAME: JP_Rpt_TaxControlFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class JP_Rpt_TaxControlFactory
	{
		public IJP_Rpt_TaxControl Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _JP_Rpt_TaxControl = new Reporting.JP_Rpt_TaxControl(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJP_Rpt_TaxControlExt = timerfactory.Create<Reporting.IJP_Rpt_TaxControl>(_JP_Rpt_TaxControl);
			
			return iJP_Rpt_TaxControlExt;
		}
	}
}
