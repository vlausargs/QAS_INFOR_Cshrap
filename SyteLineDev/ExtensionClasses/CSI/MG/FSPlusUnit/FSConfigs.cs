//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSConfigs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusUnit
{
	[IDOExtensionClass("FSConfigs")]
	public class FSConfigs : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSConfigSearchLoadSp(int? Current,
		string SerNum,
		string Item,
		string CustNum,
		string Search,
		int? UnitSer,
		int? UnitItem,
		int? UnitCustItem,
		int? UnitDesc,
		int? CompSer,
		int? CompItem,
		int? CompCustItem,
		int? CompDesc)
		{
			var iSSSFSConfigSearchLoadExt = new SSSFSConfigSearchLoadFactory().Create(this, true);
			
			var result = iSSSFSConfigSearchLoadExt.SSSFSConfigSearchLoadSp(Current,
			SerNum,
			Item,
			CustNum,
			Search,
			UnitSer,
			UnitItem,
			UnitCustItem,
			UnitDesc,
			CompSer,
			CompItem,
			CompCustItem,
			CompDesc);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConfigValidateLotSp(string Item,
		                                    string Lot,
		                                    ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSConfigValidateLotExt = new SSSFSConfigValidateLotFactory().Create(appDb);
				
				int Severity = iSSSFSConfigValidateLotExt.SSSFSConfigValidateLotSp(Item,
				                                                                   Lot,
				                                                                   ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitConfigDelSp(int? iCompID,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSUnitConfigDelExt = new SSSFSUnitConfigDelFactory().Create(appDb);
				
				int Severity = iSSSFSUnitConfigDelExt.SSSFSUnitConfigDelSp(iCompID,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitConfigUpdateFromSRO(Guid? SroTransRowPointer,
		                                        int? InCompId,
		                                        string RemoveReason,
		                                        ref decimal? MatlQtyCounter,
		                                        ref int? CfgCounter,
		                                        ref string SuccessMsg,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSUnitConfigUpdateFromSROExt = new SSSFSUnitConfigUpdateFromSROFactory().Create(appDb);
				
				var result = iSSSFSUnitConfigUpdateFromSROExt.SSSFSUnitConfigUpdateFromSROSp(SroTransRowPointer,
				                                                                             InCompId,
				                                                                             RemoveReason,
				                                                                             MatlQtyCounter,
				                                                                             CfgCounter,
				                                                                             SuccessMsg,
				                                                                             Infobar);
				
				int Severity = result.ReturnCode.Value;
				MatlQtyCounter = result.MatlQtyCounter;
				CfgCounter = result.CfgCounter;
				SuccessMsg = result.SuccessMsg;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSConfigLoadTreeLevelSp(int? ParentId,
		DateTime? AsOfDate,
		int? IncludeFuture,
		int? IncludeRemoved,
		int? IsParent)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSConfigLoadTreeLevelExt = new SSSFSConfigLoadTreeLevelFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSConfigLoadTreeLevelExt.SSSFSConfigLoadTreeLevelSp(ParentId,
				AsOfDate,
				IncludeFuture,
				IncludeRemoved,
				IsParent);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSLoadConfig(int? CompId)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSLoadConfigExt = new SSSFSLoadConfigFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSLoadConfigExt.SSSFSLoadConfigSp(CompId);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitConfigInsSp(ref int? comp_id,
		ref string description,
		ref DateTime? install_date,
		ref string item,
		ref string cust_item,
		ref string lot,
		ref int? parent_id,
		ref string ser_num,
		ref decimal? qty,
		ref string reason,
		ref DateTime? remove_date,
		ref string revision,
		ref string u_m,
		ref string Infobar,
		ref string charfld1,
		ref string charfld2,
		ref string charfld3,
		ref DateTime? datefld,
		ref decimal? decifld1,
		ref decimal? decifld2,
		ref decimal? decifld3,
		ref int? logifld,
		[Optional] string SroNum,
		[Optional] int? SroLine,
		[Optional] int? SroOper,
		[Optional] int? TransNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSUnitConfigInsExt = new SSSFSUnitConfigInsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSUnitConfigInsExt.SSSFSUnitConfigInsSp(comp_id,
				description,
				install_date,
				item,
				cust_item,
				lot,
				parent_id,
				ser_num,
				qty,
				reason,
				remove_date,
				revision,
				u_m,
				Infobar,
				charfld1,
				charfld2,
				charfld3,
				datefld,
				decifld1,
				decifld2,
				decifld3,
				logifld,
				SroNum,
				SroLine,
				SroOper,
				TransNum);
				
				int Severity = result.ReturnCode.Value;
				comp_id = result.comp_id;
				description = result.description;
				install_date = result.install_date;
				item = result.item;
				cust_item = result.cust_item;
				lot = result.lot;
				parent_id = result.parent_id;
				ser_num = result.ser_num;
				qty = result.qty;
				reason = result.reason;
				remove_date = result.remove_date;
				revision = result.revision;
				u_m = result.u_m;
				Infobar = result.Infobar;
				charfld1 = result.charfld1;
				charfld2 = result.charfld2;
				charfld3 = result.charfld3;
				datefld = result.datefld;
				decifld1 = result.decifld1;
				decifld2 = result.decifld2;
				decifld3 = result.decifld3;
				logifld = result.logifld;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitConfigUpdSp(int? iCompID,
		string description,
		DateTime? install_date,
		string item,
		string cust_item,
		string lot,
		int? parent_id,
		string ser_num,
		decimal? qty,
		string reason,
		DateTime? remove_date,
		string revision,
		string u_m,
		ref string Infobar,
		string charfld1,
		string charfld2,
		string charfld3,
		DateTime? datefld,
		decimal? decifld1,
		decimal? decifld2,
		decimal? decifld3,
		int? logifld,
		[Optional] string SroNum,
		[Optional] int? SroLine,
		[Optional] int? SroOper,
		[Optional] int? TransNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSUnitConfigUpdExt = new SSSFSUnitConfigUpdFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSUnitConfigUpdExt.SSSFSUnitConfigUpdSp(iCompID,
				description,
				install_date,
				item,
				cust_item,
				lot,
				parent_id,
				ser_num,
				qty,
				reason,
				remove_date,
				revision,
				u_m,
				Infobar,
				charfld1,
				charfld2,
				charfld3,
				datefld,
				decifld1,
				decifld2,
				decifld3,
				logifld,
				SroNum,
				SroLine,
				SroOper,
				TransNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
