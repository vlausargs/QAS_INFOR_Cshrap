//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBReportNotesViews.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.BusInterface;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.BusInterface
{
	[IDOExtensionClass("ESBReportNotesViews")]
	public class ESBReportNotesViews : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBNotesSp(string TableName,
		                          Guid? RowPointer,
		                          byte? IsInternalNote,
		                          string NoteDesc,
		                          string NoteText,
		                          ref string Infobar,
                                  short? CoLine)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBNotesExt = new LoadESBNotesFactory().Create(appDb);
				
				int Severity = iLoadESBNotesExt.LoadESBNotesSp(TableName,
				                                               RowPointer,
				                                               IsInternalNote,
				                                               NoteDesc,
				                                               NoteText,
				                                               ref Infobar,
                                                               CoLine);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBNotesSp(Guid? RowPointer)
		{
			var iCLM_ESBNotesExt = new CLM_ESBNotesFactory().Create(this, true);
			
			var result = iCLM_ESBNotesExt.CLM_ESBNotesSp(RowPointer);
			
			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}

	}
}
