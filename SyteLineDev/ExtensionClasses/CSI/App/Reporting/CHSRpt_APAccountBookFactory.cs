//PROJECT NAME: Reporting
//CLASS NAME: CHSRpt_APAccountBookFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_APAccountBookFactory
	{
		public ICHSRpt_APAccountBook Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_APAccountBook = new Reporting.CHSRpt_APAccountBook(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_APAccountBookExt = timerfactory.Create<Reporting.ICHSRpt_APAccountBook>(_CHSRpt_APAccountBook);
			
			return iCHSRpt_APAccountBookExt;
		}
	}
}
