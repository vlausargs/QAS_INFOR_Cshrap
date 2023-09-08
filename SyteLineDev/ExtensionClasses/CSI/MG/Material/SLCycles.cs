//PROJECT NAME: MaterialExt
//CLASS NAME: SLCycles.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
	[IDOExtensionClass("SLCycles")]
	public class SLCycles : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CountQtyValidateSp(string Whse,
		                              string Loc,
		                              string Item,
		                              string Lot,
		                              string SerNum,
		                              decimal? QtyCount,
		                              ref string PromptMsg,
		                              ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCountQtyValidateExt = new CountQtyValidateFactory().Create(appDb);
				
				int Severity = iCountQtyValidateExt.CountQtyValidateSp(Whse,
				                                                       Loc,
				                                                       Item,
				                                                       Lot,
				                                                       SerNum,
				                                                       QtyCount,
				                                                       ref PromptMsg,
				                                                       ref PromptButtons);
				
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CyclePostSp(string Stat,
		                             string Whse,
		                             ref int? Counter,
		                             ref string Infobar,
		                             [Optional] DateTime? PostDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCyclePostExt = new CyclePostFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCyclePostExt.CyclePostSp(Stat,
				                                       Whse,
				                                       Counter,
				                                       Infobar,
				                                       PostDate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Counter = result.Counter;
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemCcPurgeSp(byte? RollBackonProcessCount,
		                         string CurWhse,
		                         string CycleStatus,
		                         string AbcCode,
		                         string BegItem,
		                         string EndItem,
		                         string BegLoc,
		                         string EndLoc,
		                         DateTime? BegCycleDate,
		                         DateTime? EndCycleDate,
		                         string BegProductCode,
		                         string EndProductCode,
		                         string BegPlanCode,
		                         string EndPlanCode,
		                         ref int? ProcessCount,
		                         ref string Infobar,
		                         [Optional] short? StartingDateOffset,
		                         [Optional] short? EndingDateOffset,
		                         [Optional] byte? CycleFlag)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemCcPurgeExt = new ItemCcPurgeFactory().Create(appDb);
				
				var result = iItemCcPurgeExt.ItemCcPurgeSp(RollBackonProcessCount,
				                                           CurWhse,
				                                           CycleStatus,
				                                           AbcCode,
				                                           BegItem,
				                                           EndItem,
				                                           BegLoc,
				                                           EndLoc,
				                                           BegCycleDate,
				                                           EndCycleDate,
				                                           BegProductCode,
				                                           EndProductCode,
				                                           BegPlanCode,
				                                           EndPlanCode,
				                                           ProcessCount,
				                                           Infobar,
				                                           StartingDateOffset,
				                                           EndingDateOffset,
				                                           CycleFlag);
				
				int Severity = result.ReturnCode.Value;
				ProcessCount = result.ProcessCount;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemlocValidateSp(string Item,
		                             string Whse,
		                             string Loc,
		                             [Optional, DefaultParameterValue((byte)0)] byte? VerifyAccounts,
		[Optional, DefaultParameterValue((byte)0)] byte? CheckUserAccount,
		[Optional] string UserAcct,
		ref string Infobar,
		[Optional] ref string Prompt,
		[Optional] ref string PromptButtons,
		[Optional, DefaultParameterValue((byte)1)] byte? Outgoing,
		[Optional] ref decimal? ItemQtyOnHand,
		[Optional] string OldLoc,
		[Optional] string CoNum,
		[Optional] short? CoLine,
		[Optional] short? CoRelease,
		[Optional] string Lot)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemlocValidateExt = new ItemlocValidateFactory().Create(appDb);
				
				var result = iItemlocValidateExt.ItemlocValidateSp(Item,
				                                                   Whse,
				                                                   Loc,
				                                                   VerifyAccounts,
				                                                   CheckUserAccount,
				                                                   UserAcct,
				                                                   Infobar,
				                                                   Prompt,
				                                                   PromptButtons,
				                                                   Outgoing,
				                                                   ItemQtyOnHand,
				                                                   OldLoc,
				                                                   CoNum,
				                                                   CoLine,
				                                                   CoRelease,
				                                                   Lot);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				ItemQtyOnHand = result.ItemQtyOnHand;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CyclePostListSp(string Whse,
		int? Counter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCyclePostListExt = new CyclePostListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCyclePostListExt.CyclePostListSp(Whse,
				Counter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvLotV2Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		int? Step,
		ref string Infobar,
		ref string PromptMsg,
		ref string PromptButtons,
		[Optional] string Revision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvLotV2Ext = new PhyinvLotV2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvLotV2Ext.PhyinvLotV2Sp(Whse,
				Item,
				Loc,
				Lot,
				Step,
				Infobar,
				PromptMsg,
				PromptButtons,
				Revision);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PhyinvSerialV2Sp(string Whse,
		string Item,
		string Loc,
		string Lot,
		string SerNum,
		int? Step,
		ref string Infobar,
		ref string PromptMsg,
		ref string PromptButtons,
		string ImportDocId,
		[Optional] Guid? CurrentRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPhyinvSerialV2Ext = new PhyinvSerialV2Factory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPhyinvSerialV2Ext.PhyinvSerialV2Sp(Whse,
				Item,
				Loc,
				Lot,
				SerNum,
				Step,
				Infobar,
				PromptMsg,
				PromptButtons,
				ImportDocId,
				CurrentRowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}
	}
}
