//PROJECT NAME: FSPlusExt
//CLASS NAME: FSUtils.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlus
{
    [IDOExtensionClass("FSUtils")]
    public class FSUtils : ExtensionClassBase
    {        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSGetSerialInfoSp(ref string iSerNum,
                                        ref string oItem)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSGetSerialInfoExt = new SSSFSGetSerialInfoFactory().Create(appDb);

                SerNumType oiSerNum = iSerNum;
                ItemType ooItem = oItem;

                int Severity = iSSSFSGetSerialInfoExt.SSSFSGetSerialInfoSp(ref oiSerNum,
                                                                           ref ooItem);

                iSerNum = oiSerNum;
                oItem = ooItem;


                return Severity;
            }
        }
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetLotLocCostSp(string Whse,
		                                string Item,
		                                string Lot,
		                                string Loc,
		                                string UM,
		                                ref decimal? UnitCostConv,
		                                ref decimal? MatlCostConv,
		                                ref decimal? LbrCostConv,
		                                ref decimal? FovCostConv,
		                                ref decimal? VovCostConv,
		                                ref decimal? OutCostConv,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetLotLocCostExt = new SSSFSGetLotLocCostFactory().Create(appDb);
				
				int Severity = iSSSFSGetLotLocCostExt.SSSFSGetLotLocCostSp(Whse,
				                                                           Item,
				                                                           Lot,
				                                                           Loc,
				                                                           UM,
				                                                           ref UnitCostConv,
				                                                           ref MatlCostConv,
				                                                           ref LbrCostConv,
				                                                           ref FovCostConv,
				                                                           ref VovCostConv,
				                                                           ref OutCostConv,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSNotesWriteSp(string ObjectName,
		                             string NoteDesc,
		                             string NoteContent,
		                             Guid? RefRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSNotesWriteExt = new SSSFSNotesWriteFactory().Create(appDb);
				
				int Severity = iSSSFSNotesWriteExt.SSSFSNotesWriteSp(ObjectName,
				                                                     NoteDesc,
				                                                     NoteContent,
				                                                     RefRowPointer);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetItemInfoSp(string iItem,
		                              [Optional] ref string oDescription,
		                              [Optional] ref string oUM,
		                              [Optional] ref string oProductCode,
		                              [Optional] ref byte? oSerialTracked,
		                              [Optional] ref byte? oLotTracked,
		                              [Optional] ref string Revision)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetItemInfoExt = new SSSFSGetItemInfoFactory().Create(appDb);
				
				var result = iSSSFSGetItemInfoExt.SSSFSGetItemInfoSp(iItem,
				                                                     oDescription,
				                                                     oUM,
				                                                     oProductCode,
				                                                     oSerialTracked,
				                                                     oLotTracked,
				                                                     Revision);
				
				int Severity = result.ReturnCode.Value;
				oDescription = result.oDescription;
				oUM = result.oUM;
				oProductCode = result.oProductCode;
				oSerialTracked = result.oSerialTracked;
				oLotTracked = result.oLotTracked;
				Revision = result.Revision;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPartReimbProcessSp(string PPartnerId,
		                                   decimal? PMiscCharges,
		                                   decimal? PAmtDue,
		                                   Guid? SessionID,
		                                   string PVendNum,
		                                   string PInvNum,
		                                   DateTime? PInvDate,
		                                   DateTime? PDistDate,
		                                   string PBatchId,
		                                   string NoteContent,
		                                   int? PreRegister,
		                                   ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPartReimbProcessExt = new SSSFSPartReimbProcessFactory().Create(appDb);
				
				var result = iSSSFSPartReimbProcessExt.SSSFSPartReimbProcessSp(PPartnerId,
				                                                               PMiscCharges,
				                                                               PAmtDue,
				                                                               SessionID,
				                                                               PVendNum,
				                                                               PInvNum,
				                                                               PInvDate,
				                                                               PDistDate,
				                                                               PBatchId,
				                                                               NoteContent,
				                                                               PreRegister,
				                                                               InfoBar);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSDefineVariablesSp(string VariableName,
		string VariableValue,
		ref string Infobar,
		[Optional] string VariableName2,
		[Optional] string VariableValue2,
		[Optional] string VariableName3,
		[Optional] string VariableValue3,
		[Optional] string VariableName4,
		[Optional] string VariableValue4,
		[Optional] string VariableName5,
		[Optional] string VariableValue5,
		[Optional] string VariableName6,
		[Optional] string VariableValue6,
		[Optional] string VariableName7,
		[Optional] string VariableValue7,
		[Optional] string VariableName8,
		[Optional] string VariableValue8,
		[Optional] string VariableName9,
		[Optional] string VariableValue9,
		[Optional] string VariableName10,
		[Optional] string VariableValue10)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSDefineVariablesExt = new SSSFSDefineVariablesFactory().Create(appDb);
				
				var result = iSSSFSDefineVariablesExt.SSSFSDefineVariablesSp(VariableName,
				VariableValue,
				Infobar,
				VariableName2,
				VariableValue2,
				VariableName3,
				VariableValue3,
				VariableName4,
				VariableValue4,
				VariableName5,
				VariableValue5,
				VariableName6,
				VariableValue6,
				VariableName7,
				VariableValue7,
				VariableName8,
				VariableValue8,
				VariableName9,
				VariableValue9,
				VariableName10,
				VariableValue10);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetAllNotesSp(string RefType,
		string RefNum,
		[Optional] int? RefLineSuf,
		[Optional] int? RefRelease,
		[Optional] int? RefSeq,
		ref string RefNotes,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetAllNotesExt = new SSSFSGetAllNotesFactory().Create(appDb);
				
				var result = iSSSFSGetAllNotesExt.SSSFSGetAllNotesSp(RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				RefSeq,
				RefNotes,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				RefNotes = result.RefNotes;
				Infobar = result.Infobar;
				return Severity;
			}
		}






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSXrefCreateSp(string FromRefType,
		string FromRefNum,
		int? FromRefLineSuf,
		int? FromRefRelease,
		int? FromTransNum,
		string ToRefType,
		string ToRefNum,
		int? ToRefLineSuf,
		int? ToRefRelease,
		string CustNum,
		string Item,
		string ItemDescription,
		string UM,
		DateTime? DueDate,
		string Whse,
		ref string NewRefNum,
		ref int? NewRefLineSuf,
		ref int? NewRefRelease,
		ref string Infobar,
		[Optional] string FromWhse,
		[Optional] string FromSite,
		[Optional] string ToSite,
		[Optional, DefaultParameterValue(1)] int? PoChangeOrd,
		[Optional, DefaultParameterValue(0)] int? MpwxrefDelete,
		[Optional, DefaultParameterValue(0)] int? CreateProj,
		[Optional, DefaultParameterValue(0)] int? CreateProjtask,
		[Optional] string TrnLoc,
		[Optional] string FOBSite,
		[Optional, DefaultParameterValue(0)] int? CustSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSXrefCreateExt = new SSSFSXrefCreateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSXrefCreateExt.SSSFSXrefCreateSp(FromRefType,
				FromRefNum,
				FromRefLineSuf,
				FromRefRelease,
				FromTransNum,
				ToRefType,
				ToRefNum,
				ToRefLineSuf,
				ToRefRelease,
				CustNum,
				Item,
				ItemDescription,
				UM,
				DueDate,
				Whse,
				NewRefNum,
				NewRefLineSuf,
				NewRefRelease,
				Infobar,
				FromWhse,
				FromSite,
				ToSite,
				PoChangeOrd,
				MpwxrefDelete,
				CreateProj,
				CreateProjtask,
				TrnLoc,
				FOBSite,
				CustSeq);
				
				int Severity = result.ReturnCode.Value;
				NewRefNum = result.NewRefNum;
				NewRefLineSuf = result.NewRefLineSuf;
				NewRefRelease = result.NewRefRelease;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSXrefPromptSp(string PFromRefType,
		string PFromRefNum,
		int? PFromRefLineSuf,
		int? PFromRefRelease,
		string PToRefType,
		string PToRefNum,
		int? PToRefLineSuf,
		int? PToRefRelease,
		[Optional] string PCustNum,
		[Optional] int? PCustSeq,
		[Optional] string Item,
		[Optional] string UM,
		[Optional] decimal? Qty,
		[Optional] string Whse,
		[Optional] DateTime? DueDate,
		ref string TXrefDestination,
		ref int? CreateFlag,
		ref int? CreateFlag2,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		[Optional] string ToSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSXrefPromptExt = new SSSFSXrefPromptFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSXrefPromptExt.SSSFSXrefPromptSp(PFromRefType,
				PFromRefNum,
				PFromRefLineSuf,
				PFromRefRelease,
				PToRefType,
				PToRefNum,
				PToRefLineSuf,
				PToRefRelease,
				PCustNum,
				PCustSeq,
				Item,
				UM,
				Qty,
				Whse,
				DueDate,
				TXrefDestination,
				CreateFlag,
				CreateFlag2,
				PromptMsg,
				PromptButtons,
				Infobar,
				ToSite);
				
				int Severity = result.ReturnCode.Value;
				TXrefDestination = result.TXrefDestination;
				CreateFlag = result.CreateFlag;
				CreateFlag2 = result.CreateFlag2;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CurrCnvtSingleValueSp(string CurrCode,
		int? FromDomestic,
		int? UseBuyRate,
		int? RoundResult,
		[Optional] DateTime? RateDate,
		[Optional] int? RoundPlaces,
		[Optional, DefaultParameterValue("currate")] string BRateTable,
		[Optional] int? ForceRate,
		[Optional] int? FindTTFixed,
		[Optional] ref decimal? TRate,
		ref string Infobar,
		decimal? Amount,
		ref decimal? Result,
		[Optional] string Site)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCurrCnvtSingleValueExt = new CurrCnvtSingleValueFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCurrCnvtSingleValueExt.CurrCnvtSingleValueSp(CurrCode,
				FromDomestic,
				UseBuyRate,
				RoundResult,
				RateDate,
				RoundPlaces,
				BRateTable,
				ForceRate,
				FindTTFixed,
				TRate,
				Infobar,
				Amount,
				Result,
				Site);
				
				int Severity = result.ReturnCode.Value;
				TRate = result.TRate;
				Infobar = result.Infobar;
				Result = result.Result;
				return Severity;
			}
		}
    }
}

