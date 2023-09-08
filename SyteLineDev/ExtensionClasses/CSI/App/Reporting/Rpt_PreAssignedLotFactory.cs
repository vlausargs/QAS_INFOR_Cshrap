//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PreAssignedLotFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PreAssignedLotFactory
	{
		public IRpt_PreAssignedLot Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PreAssignedLot = new Reporting.Rpt_PreAssignedLot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PreAssignedLotExt = timerfactory.Create<Reporting.IRpt_PreAssignedLot>(_Rpt_PreAssignedLot);
			
			return iRpt_PreAssignedLotExt;
		}
	}
}
