//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemRevisionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemRevisionFactory
	{
		public IRpt_ItemRevision Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemRevision = new Reporting.Rpt_ItemRevision(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemRevisionExt = timerfactory.Create<Reporting.IRpt_ItemRevision>(_Rpt_ItemRevision);
			
			return iRpt_ItemRevisionExt;
		}
	}
}
