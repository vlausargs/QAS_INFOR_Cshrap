//PROJECT NAME: APSExt
//CLASS NAME: SLSHIFTnnns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Production;

using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("SLSHIFTnnns")]
    public class SLSHIFTnnns : ExtensionClassBase
    {








		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetSHIFTSp(short? AltNo,
		                                   string SHIFTID,
		                                   [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ApsGetSHIFTExt = new CLM_ApsGetSHIFTFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ApsGetSHIFTExt.CLM_ApsGetSHIFTSp(AltNo,
				                                                   SHIFTID,
				                                                   FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShiftSaveSp(string ShiftId,
		string Descr,
		int? SDay,
		string STime,
		int? EDay,
		string ETime,
		string MustCompFg,
		string OverrunFg,
		int? UpdateFlag,
		Guid? RowPointer,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShiftSaveExt = new ShiftSaveFactory().Create(appDb);
				
				var result = iShiftSaveExt.ShiftSaveSp(ShiftId,
				Descr,
				SDay,
				STime,
				EDay,
				ETime,
				MustCompFg,
				OverrunFg,
				UpdateFlag,
				RowPointer,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShopCalendarDeleteSp(string ShiftId,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShopCalendarDeleteExt = new ShopCalendarDeleteFactory().Create(appDb);
				
				var result = iShopCalendarDeleteExt.ShopCalendarDeleteSp(ShiftId,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShopCalendarSaveSp(string ShiftId,
		string Descr,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShopCalendarSaveExt = new ShopCalendarSaveFactory().Create(appDb);
				
				var result = iShopCalendarSaveExt.ShopCalendarSaveSp(ShiftId,
				Descr,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShiftDelSp(string PShift,
		Guid? RowPointer,
		int? AltNo,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShiftDelExt = new ShiftDelFactory().Create(appDb);
				
				var result = iShiftDelExt.ShiftDelSp(PShift,
				RowPointer,
				AltNo,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShiftUpdSp(string PShift,
		string Descr,
		int? SDay,
		string STime,
		int? EDay,
		string ETime,
		string MustCompFg,
		string OverrunFg,
		int? UpdateFlag,
		Guid? RowPointer,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShiftUpdExt = new ShiftUpdFactory().Create(appDb);
				
				var result = iShiftUpdExt.ShiftUpdSp(PShift,
				Descr,
				SDay,
				STime,
				EDay,
				ETime,
				MustCompFg,
				OverrunFg,
				UpdateFlag,
				RowPointer,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShopCalendarUpdateSp(string ShiftId,
		string Descr,
		int? AltNo)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShopCalendarUpdateExt = new ShopCalendarUpdateFactory().Create(appDb);
				
				var result = iShopCalendarUpdateExt.ShopCalendarUpdateSp(ShiftId,
				Descr,
				AltNo);
				
				int Severity = result.Value;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TickCalSp(string StartCal,
		[Optional] string EndCal,
		int? AltNo,
		[Optional] DateTime? StartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTickCalExt = new TickCalFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTickCalExt.TickCalSp(StartCal,
				EndCal,
				AltNo,
				StartDate);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsGetSHIFTSp(int? AltNo,
		string SHIFTID,
		ref string DESCR,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsGetSHIFTExt = new ApsGetSHIFTFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsGetSHIFTExt.ApsGetSHIFTSp(AltNo,
				SHIFTID,
				DESCR,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				DESCR = result.DESCR;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetSHIFTIntSp(string PShift,
		int? AltNo,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetSHIFTIntExt = new CLM_ApsGetSHIFTIntFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetSHIFTIntExt.CLM_ApsGetSHIFTIntSp(PShift,
				AltNo,
				FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
