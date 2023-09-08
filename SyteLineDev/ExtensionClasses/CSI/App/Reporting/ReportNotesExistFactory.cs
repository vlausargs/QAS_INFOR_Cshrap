//PROJECT NAME: App.Reporting
//CLASS NAME: ReportNotesExistFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Reporting
{
	public class ReportNotesExistFactory
	{
		public IReportNotesExist Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _ReportNotesExist = new Reporting.ReportNotesExist(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReportNotesExistExt = timerfactory.Create<Reporting.IReportNotesExist>(_ReportNotesExist);

			return iReportNotesExistExt;
		}
	}
}
