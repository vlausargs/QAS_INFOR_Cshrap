//PROJECT NAME: FSPlusUnitExt
//CLASS NAME: FSUnits.cs

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
	[IDOExtensionClass("FSUnits")]
	public class FSUnits : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetIncSRODescSp(string RefType,
		                                string RefNum,
		                                ref string Desc,
		                                ref string Partner,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetIncSRODescExt = new SSSFSGetIncSRODescFactory().Create(appDb);
				
				int Severity = iSSSFSGetIncSRODescExt.SSSFSGetIncSRODescSp(RefType,
				                                                           RefNum,
				                                                           ref Desc,
				                                                           ref Partner,
				                                                           ref Infobar);
				
				return Severity;
			}
		}







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetUnitInfoSp(string SerNum,
		ref string UnitDesc,
		ref byte? UnitExists,
		ref string UnitCustNum,
		ref int? UnitCustSeq,
		ref string UnitRegion,
		ref string Item,
		ref string ItemDesc,
		ref byte? ItemExists,
		ref string ItemUM,
		ref string PromptMsgNoUnit,
		ref string Infobar,
		[Optional] ref string UnitUsrNum,
		[Optional] ref int? UnitUsrSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetUnitInfoExt = new SSSFSGetUnitInfoFactory().Create(appDb);
				
				var result = iSSSFSGetUnitInfoExt.SSSFSGetUnitInfoSp(SerNum,
				UnitDesc,
				UnitExists,
				UnitCustNum,
				UnitCustSeq,
				UnitRegion,
				Item,
				ItemDesc,
				ItemExists,
				ItemUM,
				PromptMsgNoUnit,
				Infobar,
				UnitUsrNum,
				UnitUsrSeq);
				
				int Severity = result.ReturnCode.Value;
				UnitDesc = result.UnitDesc;
				UnitExists = result.UnitExists;
				UnitCustNum = result.UnitCustNum;
				UnitCustSeq = result.UnitCustSeq;
				UnitRegion = result.UnitRegion;
				Item = result.Item;
				ItemDesc = result.ItemDesc;
				ItemExists = result.ItemExists;
				ItemUM = result.ItemUM;
				PromptMsgNoUnit = result.PromptMsgNoUnit;
				Infobar = result.Infobar;
				UnitUsrNum = result.UnitUsrNum;
				UnitUsrSeq = result.UnitUsrSeq;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitConfigCreateSP(string InSerNum,
		byte? InSubUnit,
		[Optional, DefaultParameterValue((byte)0)] byte? InAppend,
		[Optional, DefaultParameterValue((byte)0)] byte? InBatch,
		string InCopyFrom,
		[Optional] string InCpySerNum,
		[Optional] string InCopyItem,
		[Optional] string InJob,
		[Optional] short? InSuffix,
		[Optional, DefaultParameterValue(null)] string InItem,
		int? InParentID,
		[Optional] DateTime? InInstallDate,
		[Optional, DefaultParameterValue((byte)1)] byte? InCopyWarr,
		ref string Infobar,
		[Optional] string InCustNum,
		[Optional] int? InCustSeq,
		[Optional] string InUsrNum,
		[Optional] int? InUsrSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSUnitConfigCreateExt = new SSSFSUnitConfigCreateFactory().Create(appDb);
				
				var result = iSSSFSUnitConfigCreateExt.SSSFSUnitConfigCreateSP(InSerNum,
				InSubUnit,
				InAppend,
				InBatch,
				InCopyFrom,
				InCpySerNum,
				InCopyItem,
				InJob,
				InSuffix,
				InItem,
				InParentID,
				InInstallDate,
				InCopyWarr,
				Infobar,
				InCustNum,
				InCustSeq,
				InUsrNum,
				InUsrSeq);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitCustomerUpdateSp(string CustNum,
		int? CustSeq,
		string Target,
		string RefNum,
		string SerNum,
		ref string Infobar,
		[Optional] string UsrNum,
		[Optional] int? UsrSeq,
		string Item)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSUnitCustomerUpdateExt = new SSSFSUnitCustomerUpdateFactory().Create(appDb);
				
				var result = iSSSFSUnitCustomerUpdateExt.SSSFSUnitCustomerUpdateSp(CustNum,
				CustSeq,
				Target,
				RefNum,
				SerNum,
				Infobar,
				UsrNum,
				UsrSeq,
				Item);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSUnitByLoadSp(string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string Item,
		string Unit)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSUnitByLoadExt = new SSSFSUnitByLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSUnitByLoadExt.SSSFSUnitByLoadSp(CustNum,
				CustSeq,
				UsrNum,
				UsrSeq,
				Item,
				Unit);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUnitConfigCreateUtilSP([Optional, DefaultParameterValue(0)] int? ByJob,
		[Optional] string JobStart,
		[Optional] int? JobSufStart,
		[Optional] string ItemJobStart,
		[Optional] string ProductCodeStart,
		[Optional] DateTime? JobDateStart,
		[Optional] int? JobDateStartOffSET,
		[Optional] string JobEND,
		[Optional] int? JobSufEND,
		[Optional] string ItemJobEND,
		[Optional] string ProductCodeEND,
		[Optional] DateTime? JobDateEND,
		[Optional] int? JobDateEndOffSET,
		[Optional, DefaultParameterValue(0)] int? BySerNum,
		[Optional] string SerNumStart,
		[Optional] string ItemSerNumStart,
		[Optional] string SerNumEND,
		[Optional] string ItemSerNumEND,
		[Optional] int? SubCompUnits,
		[Optional] int? NonSerUnits,
		[Optional] string NonSerPrefix,
		ref string Infobar,
        [Optional] DateTime? ShipDateStart,
        [Optional] DateTime? ShipDateEnd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSUnitConfigCreateUtilExt = new SSSFSUnitConfigCreateUtilFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSUnitConfigCreateUtilExt.SSSFSUnitConfigCreateUtilSP(ByJob,
				JobStart,
				JobSufStart,
				ItemJobStart,
				ProductCodeStart,
				JobDateStart,
				JobDateStartOffSET,
				JobEND,
				JobSufEND,
				ItemJobEND,
				ProductCodeEND,
				JobDateEND,
				JobDateEndOffSET,
				BySerNum,
				SerNumStart,
				ItemSerNumStart,
				SerNumEND,
				ItemSerNumEND,
				SubCompUnits,
				NonSerUnits,
				NonSerPrefix,
				Infobar,
                ShipDateStart,
                ShipDateEnd);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSUnitWarrLoadSp(string CustNum,
		string UsrNum,
		[Optional] DateTime? IncDate,
		[Optional] decimal? MeterAmt,
		[Optional] string SerNum,
		[Optional] string Item,
		[Optional] int? CustSeq,
		[Optional] int? UsrSeq,
		[Optional] string Mode,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSUnitWarrLoadExt = new SSSFSUnitWarrLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSUnitWarrLoadExt.SSSFSUnitWarrLoadSp(CustNum,
				UsrNum,
				IncDate,
				MeterAmt,
				SerNum,
				Item,
				CustSeq,
				UsrSeq,
				Mode,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
