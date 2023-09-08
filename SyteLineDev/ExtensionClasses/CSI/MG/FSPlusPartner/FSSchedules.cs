//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSSchedules.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Partner;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusPartner
{
    [IDOExtensionClass("FSSchedules")]
    public class FSSchedules : ExtensionClassBase
    {



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SchedImportPartnerRouteSp(Guid? SessionID,
		                                     string ProfileUsername,
		                                     string ScheduleID,
		                                     int? Seq,
		                                     string PartnerId,
		                                     string Description,
		                                     string RefType,
		                                     string RefNum,
		                                     int? RefLineSuf,
		                                     int? RefRelease,
		                                     int? RefSeq,
		                                     Guid? RowPointer,
		                                     ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSchedImportPartnerRouteExt = new SchedImportPartnerRouteFactory().Create(appDb);
				
				int Severity = iSchedImportPartnerRouteExt.SchedImportPartnerRouteSp(SessionID,
				                                                                     ProfileUsername,
				                                                                     ScheduleID,
				                                                                     Seq,
				                                                                     PartnerId,
				                                                                     Description,
				                                                                     RefType,
				                                                                     RefNum,
				                                                                     RefLineSuf,
				                                                                     RefRelease,
				                                                                     RefSeq,
				                                                                     RowPointer,
				                                                                     ref Infobar);
				
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SchedUpdateRefStatSp(Guid? RowPointer,
		                                string StatCode,
		                                ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSchedUpdateRefStatExt = new SchedUpdateRefStatFactory().Create(appDb);
				
				int Severity = iSchedUpdateRefStatExt.SchedUpdateRefStatSp(RowPointer,
				                                                           StatCode,
				                                                           ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedApptPostSaveSp(string SroNum,
		                                    string StatCode,
		                                    byte? Response,
		                                    Guid? ApptRowPtr,
		                                    Guid? ApptParentRowPtr)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedApptPostSaveExt = new SSSFSSchedApptPostSaveFactory().Create(appDb);
				
				int Severity = iSSSFSSchedApptPostSaveExt.SSSFSSchedApptPostSaveSp(SroNum,
				                                                                   StatCode,
				                                                                   Response,
				                                                                   ApptRowPtr,
				                                                                   ApptParentRowPtr);
				
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSWSSchedSaveSp(Guid? RowPointer,
		                              Guid? ParentRowPointer,
		                              string PartnerId,
		                              DateTime? SchedDate,
		                              decimal? Hrs,
		                              int? NewDaySeq,
		                              int? NewTaskSeq,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSWSSchedSaveExt = new SSSFSWSSchedSaveFactory().Create(appDb);
				
				int Severity = iSSSFSWSSchedSaveExt.SSSFSWSSchedSaveSp(RowPointer,
				                                                       ParentRowPointer,
				                                                       PartnerId,
				                                                       SchedDate,
				                                                       Hrs,
				                                                       NewDaySeq,
				                                                       NewTaskSeq,
				                                                       ref Infobar);
				
				return Severity;
			}
		}








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SchedLoadPartnerFilterSp(string Username,
		string FilterName,
		int? FilterType,
		ref string PartnerList,
		ref string CertList,
		ref string SkillList,
		ref string DeptList,
		ref byte? UseCoverage,
		ref string Country,
		ref string State,
		ref string City,
		ref string Zip,
		ref string County,
		ref string Region,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSchedLoadPartnerFilterExt = new SchedLoadPartnerFilterFactory().Create(appDb);
				
				var result = iSchedLoadPartnerFilterExt.SchedLoadPartnerFilterSp(Username,
				FilterName,
				FilterType,
				PartnerList,
				CertList,
				SkillList,
				DeptList,
				UseCoverage,
				Country,
				State,
				City,
				Zip,
				County,
				Region,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				PartnerList = result.PartnerList;
				CertList = result.CertList;
				SkillList = result.SkillList;
				DeptList = result.DeptList;
				UseCoverage = result.UseCoverage;
				Country = result.Country;
				State = result.State;
				City = result.City;
				Zip = result.Zip;
				County = result.County;
				Region = result.Region;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSDispatchEventSp(string RefType,
		string IncNum,
		string Partner,
		DateTime? DispDate,
		string NoteContent,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSDispatchEventExt = new SSSFSDispatchEventFactory().Create(appDb);
				
				var result = iSSSFSDispatchEventExt.SSSFSDispatchEventSp(RefType,
				IncNum,
				Partner,
				DispDate,
				NoteContent,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedDispatchEmailDefInfoSp(string PartnerId,
		ref string FromEmailAddr,
		ref string ToEmailAddr,
		ref string EmailSubject,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedDispatchEmailDefInfoExt = new SSSFSSchedDispatchEmailDefInfoFactory().Create(appDb);
				
				var result = iSSSFSSchedDispatchEmailDefInfoExt.SSSFSSchedDispatchEmailDefInfoSp(PartnerId,
				FromEmailAddr,
				ToEmailAddr,
				EmailSubject,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				FromEmailAddr = result.FromEmailAddr;
				ToEmailAddr = result.ToEmailAddr;
				EmailSubject = result.EmailSubject;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedHasConflictsSp(string PartnerID,
		DateTime? SchedDate,
		decimal? Hrs,
		ref byte? Conflict)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSchedHasConflictsExt = new SSSFSSchedHasConflictsFactory().Create(appDb);
				
				var result = iSSSFSSchedHasConflictsExt.SSSFSSchedHasConflictsSp(PartnerID,
				SchedDate,
				Hrs,
				Conflict);
				
				int Severity = result.ReturnCode.Value;
				Conflict = result.Conflict;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SchedUpdateApptStatSp(Guid? RowPointer,
		string StatCode,
		ref string Infobar,
		[Optional] Guid? ParentRowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSchedUpdateApptStatExt = new SchedUpdateApptStatFactory().Create(appDb);
				
				var result = iSchedUpdateApptStatExt.SchedUpdateApptStatSp(RowPointer,
				StatCode,
				Infobar,
				ParentRowPointer);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SchedImportPartnerRoutePostSp(Guid? SessionID,
		string ProfileUsername,
		string ScheduleID,
		string PartnerID,
		DateTime? NextApptDate,
		string Durations,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSchedImportPartnerRoutePostExt = new SchedImportPartnerRoutePostFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSchedImportPartnerRoutePostExt.SchedImportPartnerRoutePostSp(SessionID,
				ProfileUsername,
				ScheduleID,
				PartnerID,
				NextApptDate,
				Durations,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SchedUpdateApptDetailSp(Guid? RowPointer,
		DateTime? RecordDate,
		[Optional, DefaultParameterValue(0)] int? StatCodeChanged,
		[Optional] string StatCode,
		[Optional] string PartnerID,
		[Optional, DefaultParameterValue(0)] int? GPSOnline,
		[Optional] decimal? Latitude,
		[Optional] decimal? Longitude,
		[Optional] DateTime? GPSLocDate,
		[Optional, DefaultParameterValue(0)] int? NotesChanged,
		[Optional] string Notes,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSchedUpdateApptDetailExt = new SchedUpdateApptDetailFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSchedUpdateApptDetailExt.SchedUpdateApptDetailSp(RowPointer,
				RecordDate,
				StatCodeChanged,
				StatCode,
				PartnerID,
				GPSOnline,
				Latitude,
				Longitude,
				GPSLocDate,
				NotesChanged,
				Notes,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SchedUpdatePartnerSp(Guid? RowPointer,
		Guid? NewRowPointer,
		string PartnerId,
		DateTime? StartDate,
		int? View,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSchedUpdatePartnerExt = new SchedUpdatePartnerFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSchedUpdatePartnerExt.SchedUpdatePartnerSp(RowPointer,
				NewRowPointer,
				PartnerId,
				StartDate,
				View,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSchedDispatchPartnerLoadSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		Guid? RefRowPointer,
		DateTime? RequestDate,
		int? DaysToLookAhead,
		decimal? ApptHrs,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSchedDispatchPartnerLoadExt = new SSSFSSchedDispatchPartnerLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSchedDispatchPartnerLoadExt.SSSFSSchedDispatchPartnerLoadSp(RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				RefSeq,
				RefRowPointer,
				RequestDate,
				DaysToLookAhead,
				ApptHrs,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedDispatchPartnerSaveSp(string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		int? RefSeq,
		string PartnerId,
		DateTime? SchedDate,
		string ApptType,
		string ApptStat,
		string ApptDesc,
		decimal? ApptHrs,
		string NotesContent,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSchedDispatchPartnerSaveExt = new SSSFSSchedDispatchPartnerSaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSchedDispatchPartnerSaveExt.SSSFSSchedDispatchPartnerSaveSp(RefType,
				RefNum,
				RefLineSuf,
				RefRelease,
				RefSeq,
				PartnerId,
				SchedDate,
				ApptType,
				ApptStat,
				ApptDesc,
				ApptHrs,
				NotesContent,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSchedRescheduleLoadSp(string RowPointers,
		string PartnerID,
		decimal? MoveAmount,
		string MoveUnit,
		int? SchedMethod,
		string ApptStat,
		int? UseMaxHrs,
		int? UseProfileEndOfDay)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSchedRescheduleLoadExt = new SSSFSSchedRescheduleLoadFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSchedRescheduleLoadExt.SSSFSSchedRescheduleLoadSp(RowPointers,
				PartnerID,
				MoveAmount,
				MoveUnit,
				SchedMethod,
				ApptStat,
				UseMaxHrs,
				UseProfileEndOfDay);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSSchedTeamLoadConflictSp(string PartnerId,
		string SchedDate,
		string Hrs,
		string NewApptRowPtr,
		string NewApptRowNum,
		ref string Infobar,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSchedTeamLoadConflictExt = new SSSFSSchedTeamLoadConflictFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSchedTeamLoadConflictExt.SSSFSSchedTeamLoadConflictSp(PartnerId,
				SchedDate,
				Hrs,
				NewApptRowPtr,
				NewApptRowNum,
				Infobar,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSchedValidSchedDateSp(DateTime? SchedDate,
		[Optional] string PartnerId,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSSchedValidSchedDateExt = new SSSFSSchedValidSchedDateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSSchedValidSchedDateExt.SSSFSSchedValidSchedDateSp(SchedDate,
				PartnerId,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
