//PROJECT NAME: FSPlusCallCenterExt
//CLASS NAME: FSIncidents.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.CallCenter;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.Portals;

namespace CSI.MG.FSPlusCallCenter
{
    [IDOExtensionClass("FSIncidents")]
    public class FSIncidents : CSIExtensionClassBase, IFSIncidents
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalValidateIncidentRequestSp(string CustNum,
		                                                string CustSeq,
		                                                string Username,
		                                                string SerNum,
		                                                string Item,
		                                                string Site,
		                                                string PriorCode,
		                                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalValidateIncidentRequestExt = new SSSFSPortalValidateIncidentRequestFactory().Create(appDb);
				
				int Severity = iSSSFSPortalValidateIncidentRequestExt.SSSFSPortalValidateIncidentRequestSp(CustNum,
				                                                                                           CustSeq,
				                                                                                           Username,
				                                                                                           SerNum,
				                                                                                           Item,
				                                                                                           Site,
				                                                                                           PriorCode,
				                                                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncPriorityDatesSp(string PriorCode,
		                                   DateTime? IncDateTime,
		                                   string CustNum,
		                                   string SerNum,
		                                   string Item,
		                                   ref DateTime? FollowupDateTime,
		                                   ref DateTime? WarningDateTime,
		                                   ref DateTime? LateDateTime,
		                                   ref string InfoBar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSIncPriorityDatesExt = new SSSFSIncPriorityDatesFactory().Create(appDb);
				
				int Severity = iSSSFSIncPriorityDatesExt.SSSFSIncPriorityDatesSp(PriorCode,
				                                                                 IncDateTime,
				                                                                 CustNum,
				                                                                 SerNum,
				                                                                 Item,
				                                                                 ref FollowupDateTime,
				                                                                 ref WarningDateTime,
				                                                                 ref LateDateTime,
				                                                                 ref InfoBar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncCalcDurationSp(string iIncNum,
		                                  byte? iUpdateInc,
		                                  ref decimal? oDuration,
		                                  ref string oDurationUnits,
		                                  ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSIncCalcDurationExt = new SSSFSIncCalcDurationFactory().Create(appDb);
				
				int Severity = iSSSFSIncCalcDurationExt.SSSFSIncCalcDurationSp(iIncNum,
				                                                               iUpdateInc,
				                                                               ref oDuration,
				                                                               ref oDurationUnits,
				                                                               ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConsoleCreateValidCustSp(string CustNum,
		                                         ref int? CustSeq,
		                                         string UsrNum,
		                                         int? UsrSeq,
		                                         ref string Name,
		                                         ref string SerNum,
		                                         ref byte? UnitExists,
		                                         ref string Item,
		                                         ref string Contact,
		                                         ref string Email,
		                                         ref string Phone,
		                                         ref string Infobar,
		                                         ref string PriorCode,
		                                         ref string ShipToName,
		                                         [Optional] string IncPriorCode,
		                                         [Optional] string PriorCustNum,
		                                         [Optional, DefaultParameterValue("1")] string Level)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSConsoleCreateValidCustExt = new SSSFSConsoleCreateValidCustFactory().Create(appDb);
				
				var result = iSSSFSConsoleCreateValidCustExt.SSSFSConsoleCreateValidCustSp(CustNum,
				                                                                           CustSeq,
				                                                                           UsrNum,
				                                                                           UsrSeq,
				                                                                           Name,
				                                                                           SerNum,
				                                                                           UnitExists,
				                                                                           Item,
				                                                                           Contact,
				                                                                           Email,
				                                                                           Phone,
				                                                                           Infobar,
				                                                                           PriorCode,
				                                                                           ShipToName,
				                                                                           IncPriorCode,
				                                                                           PriorCustNum,
				                                                                           Level);
				
				int Severity = result.ReturnCode.Value;
				CustSeq = result.CustSeq;
				Name = result.Name;
				SerNum = result.SerNum;
				UnitExists = result.UnitExists;
				Item = result.Item;
				Contact = result.Contact;
				Email = result.Email;
				Phone = result.Phone;
				Infobar = result.Infobar;
				PriorCode = result.PriorCode;
				ShipToName = result.ShipToName;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSPortalCreateIncidentSp(string CustNum,
		                                       int? CustSeq,
		                                       string Username,
		                                       string SerNum,
		                                       string Item,
		                                       string Site,
		                                       string PriorCode,
		                                       string Contact,
		                                       string Phone,
		                                       string FaxNum,
		                                       string Email,
		                                       string Description,
		                                       string IncNotes,
		                                       [Optional, DefaultParameterValue((byte)0)] byte? Validate,
		ref string IncNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSPortalCreateIncidentExt = new SSSFSPortalCreateIncidentFactory().Create(appDb);
				
				var result = iSSSFSPortalCreateIncidentExt.SSSFSPortalCreateIncidentSp(CustNum,
				                                                                       CustSeq,
				                                                                       Username,
				                                                                       SerNum,
				                                                                       Item,
				                                                                       Site,
				                                                                       PriorCode,
				                                                                       Contact,
				                                                                       Phone,
				                                                                       FaxNum,
				                                                                       Email,
				                                                                       Description,
				                                                                       IncNotes,
				                                                                       Validate,
				                                                                       IncNum,
				                                                                       Infobar);
				
				int Severity = result.ReturnCode.Value;
				IncNum = result.IncNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetNotesSp(string RowPointer,
		                           ref string ReturnNotes,
		                           [Optional, DefaultParameterValue((byte)0)] byte? InternalOnly,
		[Optional, DefaultParameterValue((byte)0)] byte? ExternalOnly)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSGetNotesExt = new SSSFSGetNotesFactory().Create(appDb);
				
				var result = iSSSFSGetNotesExt.SSSFSGetNotesSp(RowPointer,
				                                               ReturnNotes,
				                                               InternalOnly,
				                                               ExternalOnly);
				
				int Severity = result.ReturnCode.Value;
				ReturnNotes = result.ReturnNotes;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncDefaultsSp(ref string PriorCode,
		                              ref string PriorCodeDesc,
		                              ref string StatCode,
		                              ref string StatCodeDesc,
		                              ref string SSR,
		                              ref string SSRName,
		                              ref byte? UseConsumer,
		                              ref string Infobar,
		                              [Optional, DefaultParameterValue((byte)0)] ref byte? ToBeScheduled,
		[Optional] ref string Dept)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSIncDefaultsExt = new SSSFSIncDefaultsFactory().Create(appDb);
				
				var result = iSSSFSIncDefaultsExt.SSSFSIncDefaultsSp(PriorCode,
				                                                     PriorCodeDesc,
				                                                     StatCode,
				                                                     StatCodeDesc,
				                                                     SSR,
				                                                     SSRName,
				                                                     UseConsumer,
				                                                     Infobar,
				                                                     ToBeScheduled,
				                                                     Dept);
				
				int Severity = result.ReturnCode.Value;
				PriorCode = result.PriorCode;
				PriorCodeDesc = result.PriorCodeDesc;
				StatCode = result.StatCode;
				StatCodeDesc = result.StatCodeDesc;
				SSR = result.SSR;
				SSRName = result.SSRName;
				UseConsumer = result.UseConsumer;
				Infobar = result.Infobar;
				ToBeScheduled = result.ToBeScheduled;
				Dept = result.Dept;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncGetItemInfoSp(string Item,
		                                 string CustNum,
		                                 int? CustSeq,
		                                 string SerNum,
		                                 DateTime? IncDateTime,
		                                 ref string CustItem,
		                                 ref string PriorCode,
		                                 ref string Infobar,
		                                 [Optional] ref string Description,
		                                 [Optional] ref string UM,
		                                 [Optional] ref string PromptMsg,
		                                 ref byte? ItemExist,
		                                 [Optional, DefaultParameterValue((byte)0)] ref byte? IsOpenNonInvForm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSIncGetItemInfoExt = new SSSFSIncGetItemInfoFactory().Create(appDb);
				
				var result = iSSSFSIncGetItemInfoExt.SSSFSIncGetItemInfoSp(Item,
				                                                           CustNum,
				                                                           CustSeq,
				                                                           SerNum,
				                                                           IncDateTime,
				                                                           CustItem,
				                                                           PriorCode,
				                                                           Infobar,
				                                                           Description,
				                                                           UM,
				                                                           PromptMsg,
				                                                           ItemExist,
				                                                           IsOpenNonInvForm);
				
				int Severity = result.ReturnCode.Value;
				CustItem = result.CustItem;
				PriorCode = result.PriorCode;
				Infobar = result.Infobar;
				Description = result.Description;
				UM = result.UM;
				PromptMsg = result.PromptMsg;
				ItemExist = result.ItemExist;
				IsOpenNonInvForm = result.IsOpenNonInvForm;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncGetUnitInfoSp(string IncNum,
		                                 string IncCustNum,
		                                 int? IncCustSeq,
		                                 string SerNum,
		                                 ref string UnitDesc,
		                                 ref byte? UnitExists,
		                                 ref string UnitCustNum,
		                                 ref int? UnitCustSeq,
		                                 ref string Item,
		                                 ref string ItemDesc,
		                                 ref byte? ItemExists,
		                                 ref string ItemUM,
		                                 ref string UnitRegion,
		                                 ref string RegionDesc,
		                                 ref string PromptMsgBadCust,
		                                 ref string PromptMsgNoUnit,
		                                 ref string Infobar,
		                                 ref string PriorCode,
		                                 ref string PriorCodeDesc,
		                                 ref string CustItem,
		                                 [Optional] string IncPriorCode,
		                                 [Optional] ref string UnitUsrNum,
		                                 [Optional] ref int? UnitUsrSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSIncGetUnitInfoExt = new SSSFSIncGetUnitInfoFactory().Create(appDb);
				
				var result = iSSSFSIncGetUnitInfoExt.SSSFSIncGetUnitInfoSp(IncNum,
				                                                           IncCustNum,
				                                                           IncCustSeq,
				                                                           SerNum,
				                                                           UnitDesc,
				                                                           UnitExists,
				                                                           UnitCustNum,
				                                                           UnitCustSeq,
				                                                           Item,
				                                                           ItemDesc,
				                                                           ItemExists,
				                                                           ItemUM,
				                                                           UnitRegion,
				                                                           RegionDesc,
				                                                           PromptMsgBadCust,
				                                                           PromptMsgNoUnit,
				                                                           Infobar,
				                                                           PriorCode,
				                                                           PriorCodeDesc,
				                                                           CustItem,
				                                                           IncPriorCode,
				                                                           UnitUsrNum,
				                                                           UnitUsrSeq);
				
				int Severity = result.ReturnCode.Value;
				UnitDesc = result.UnitDesc;
				UnitExists = result.UnitExists;
				UnitCustNum = result.UnitCustNum;
				UnitCustSeq = result.UnitCustSeq;
				Item = result.Item;
				ItemDesc = result.ItemDesc;
				ItemExists = result.ItemExists;
				ItemUM = result.ItemUM;
				UnitRegion = result.UnitRegion;
				RegionDesc = result.RegionDesc;
				PromptMsgBadCust = result.PromptMsgBadCust;
				PromptMsgNoUnit = result.PromptMsgNoUnit;
				Infobar = result.Infobar;
				PriorCode = result.PriorCode;
				PriorCodeDesc = result.PriorCodeDesc;
				CustItem = result.CustItem;
				UnitUsrNum = result.UnitUsrNum;
				UnitUsrSeq = result.UnitUsrSeq;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int IncidentPreDeleteSp(string IncNum,
			ref string Infobar)
		{
			var iIncidentPreDeleteExt = new IncidentPreDeleteFactory().Create(this, true);
			
			var result = iIncidentPreDeleteExt.IncidentPreDeleteSp(IncNum,
				Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConsoleCreateIncSp(string SSR,
		string Site,
		string Owner,
		string WorkSite,
		string PriorCode,
		string StatCode,
		string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string SerNum,
		string Item,
		string Contact,
		string Email,
		string Phone,
		string GenReason,
		string SpecReason,
		string IncNotes,
		string ReasonNotes,
		ref string IncNum,
		ref string Infobar,
		string CustItem,
		[Optional] ref string UM,
		[Optional] string Description,
		[Optional, DefaultParameterValue(0)] int? GPSOnline,
		[Optional] decimal? Latitude,
		[Optional] decimal? Longitude,
		[Optional] DateTime? GPSLocDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSConsoleCreateIncExt = new SSSFSConsoleCreateIncFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSConsoleCreateIncExt.SSSFSConsoleCreateIncSp(SSR,
				Site,
				Owner,
				WorkSite,
				PriorCode,
				StatCode,
				CustNum,
				CustSeq,
				UsrNum,
				UsrSeq,
				SerNum,
				Item,
				Contact,
				Email,
				Phone,
				GenReason,
				SpecReason,
				IncNotes,
				ReasonNotes,
				IncNum,
				Infobar,
				CustItem,
				UM,
				Description,
				GPSOnline,
				Latitude,
				Longitude,
				GPSLocDate);
				
				int Severity = result.ReturnCode.Value;
				IncNum = result.IncNum;
				Infobar = result.Infobar;
				UM = result.UM;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSIncNoteExactRecordDateSp(decimal? SpecificNoteToken,
		ref string ExactRecordDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSIncNoteExactRecordDateExt = new SSSFSIncNoteExactRecordDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSIncNoteExactRecordDateExt.SSSFSIncNoteExactRecordDateSp(SpecificNoteToken,
				ExactRecordDate);
				
				int Severity = result.ReturnCode.Value;
				ExactRecordDate = result.ExactRecordDate;
				return Severity;
			}
		}
    }
}

