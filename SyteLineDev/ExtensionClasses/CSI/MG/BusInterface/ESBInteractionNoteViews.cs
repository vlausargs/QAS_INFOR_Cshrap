//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBInteractionNoteViews.cs

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
	[IDOExtensionClass("ESBInteractionNoteViews")]
	public class ESBInteractionNoteViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBInteractionNoteSp(string Note,
		                                    string noteID,
		                                    string InternalExternal,
		                                    string Author,
		                                    DateTime? entryDateTime,
		                                    string InteractionType,
		                                    decimal? InteractionID,
		                                    string InteractionRefNum,
		                                    int? InteractionRefSeq,
		                                    int? InteractionSeq,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBInteractionNoteExt = new LoadESBInteractionNoteFactory().Create(appDb);
				
				int Severity = iLoadESBInteractionNoteExt.LoadESBInteractionNoteSp(Note,
				                                                                   noteID,
				                                                                   InternalExternal,
				                                                                   Author,
				                                                                   entryDateTime,
				                                                                   InteractionType,
				                                                                   InteractionID,
				                                                                   InteractionRefNum,
				                                                                   InteractionRefSeq,
				                                                                   InteractionSeq,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBInteractionNoteSp(string InteractionType,
		string InteractionRefNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBInteractionNoteExt = new CLM_ESBInteractionNoteFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBInteractionNoteExt.CLM_ESBInteractionNoteSp(InteractionType,
				InteractionRefNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
