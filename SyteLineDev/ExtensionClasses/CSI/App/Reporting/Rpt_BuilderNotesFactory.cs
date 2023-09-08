//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BuilderNotesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_BuilderNotesFactory
	{
		public IRpt_BuilderNotes Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_BuilderNotes = new Reporting.Rpt_BuilderNotes(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_BuilderNotesExt = timerfactory.Create<Reporting.IRpt_BuilderNotes>(_Rpt_BuilderNotes);
			
			return iRpt_BuilderNotesExt;
		}
	}
}
