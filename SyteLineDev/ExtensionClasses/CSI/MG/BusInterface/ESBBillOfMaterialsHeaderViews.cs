//PROJECT NAME: BusInterfaceExt
//CLASS NAME: ESBBillOfMaterialsHeaderViews.cs

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
	[IDOExtensionClass("ESBBillOfMaterialsHeaderViews")]
	public class ESBBillOfMaterialsHeaderViews : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBillOfMaterialsPostSp(string ParentItem,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBillOfMaterialsPostExt = new LoadESBBillOfMaterialsPostFactory().Create(appDb);
				
				int Severity = iLoadESBBillOfMaterialsPostExt.LoadESBBillOfMaterialsPostSp(ParentItem,
				                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int LoadESBBillOfMaterialsSp(string ParentItem,
		                                    string ActionExpression,
		                                    string RevisionID,
		                                    string Description,
		                                    string Stat,
		                                    string DocRevision,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iLoadESBBillOfMaterialsExt = new LoadESBBillOfMaterialsFactory().Create(appDb);
				
				int Severity = iLoadESBBillOfMaterialsExt.LoadESBBillOfMaterialsSp(ParentItem,
				                                                                   ActionExpression,
				                                                                   RevisionID,
				                                                                   Description,
				                                                                   Stat,
				                                                                   DocRevision,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESBBillOfMaterialsHeaderSp(string Job,
		int? Suffix)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESBBillOfMaterialsHeaderExt = new CLM_ESBBillOfMaterialsHeaderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESBBillOfMaterialsHeaderExt.CLM_ESBBillOfMaterialsHeaderSp(Job,
				Suffix);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
