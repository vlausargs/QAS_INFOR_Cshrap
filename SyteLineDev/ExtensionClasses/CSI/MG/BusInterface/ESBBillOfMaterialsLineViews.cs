//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBBillOfMaterialsLineViews.cs

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
	[IDOExtensionClass("ESBBillOfMaterialsLineViews")]
	public class ESBBillOfMaterialsLineViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBillOfMaterialLinesSp(string Item,
		                                        string ParentItem,
		                                        string RevisionID,
		                                        int? OperNum,
		                                        short? BomSeq,
		                                        decimal? QtyReleased,
		                                        string Wc,
		                                        string ParentDescription,
		                                        string Stat,
		                                        string DocRevision,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBillOfMaterialLinesExt = new LoadESBBillOfMaterialLinesFactory().Create(appDb);
				
				int Severity = iLoadESBBillOfMaterialLinesExt.LoadESBBillOfMaterialLinesSp(Item,
				                                                                           ParentItem,
				                                                                           RevisionID,
				                                                                           OperNum,
				                                                                           BomSeq,
				                                                                           QtyReleased,
				                                                                           Wc,
				                                                                           ParentDescription,
				                                                                           Stat,
				                                                                           DocRevision,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBBillOfMaterialsLineSp(string Job,
		int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBBillOfMaterialsLineExt = new CLM_ESBBillOfMaterialsLineFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBBillOfMaterialsLineExt.CLM_ESBBillOfMaterialsLineSp(Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
