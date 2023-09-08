//PROJECT NAME: APSExt
//CLASS NAME: SLSHIFTEXDInnns.cs

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
    [IDOExtensionClass("SLSHIFTEXDInnns")]
    public class SLSHIFTEXDInnns : ExtensionClassBase
    {





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DeleteShiftExceptionSP(string FromResource,
		                                  string ToResource,
		                                  DateTime? FromStartTime,
		                                  DateTime? ToStartTime,
		                                  string Exception,
		                                  short? AltNo,
		                                  ref string Infobar,
		                                  [Optional] short? StartingTransDateOffset,
		                                  [Optional] short? EndingTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDeleteShiftExceptionExt = new DeleteShiftExceptionFactory().Create(appDb);
				
				var result = iDeleteShiftExceptionExt.DeleteShiftExceptionSP(FromResource,
				                                                             ToResource,
				                                                             FromStartTime,
				                                                             ToStartTime,
				                                                             Exception,
				                                                             AltNo,
				                                                             Infobar,
				                                                             StartingTransDateOffset,
				                                                             EndingTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ShiftExceptionSp(string FromResourceGroup,
		string ToResourceGroup,
		string ExceptionDescr,
		DateTime? StartDate,
		DateTime? EndDate,
		string Work,
		string Shift,
		int? AltNo,
		ref int? CounterItem,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iShiftExceptionExt = new ShiftExceptionFactory().Create(appDb);
				
				var result = iShiftExceptionExt.ShiftExceptionSp(FromResourceGroup,
				ToResourceGroup,
				ExceptionDescr,
				StartDate,
				EndDate,
				Work,
				Shift,
				AltNo,
				CounterItem,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				CounterItem = result.CounterItem;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsSHIFTEXDIDelSp(int? AltNo,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsSHIFTEXDIDelExt = new ApsSHIFTEXDIDelFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsSHIFTEXDIDelExt.ApsSHIFTEXDIDelSp(AltNo,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsSHIFTEXDISaveSp(int? InsertFlag,
		int? AltNo,
		string SHIFTEXID,
		string DESCR,
		string SHIFTID,
		string TYPECD,
		string RESORTYPE,
		DateTime? STARTDATE,
		DateTime? ENDDATE,
		string WORKFG)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsSHIFTEXDISaveExt = new ApsSHIFTEXDISaveFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsSHIFTEXDISaveExt.ApsSHIFTEXDISaveSp(InsertFlag,
				AltNo,
				SHIFTEXID,
				DESCR,
				SHIFTID,
				TYPECD,
				RESORTYPE,
				STARTDATE,
				ENDDATE,
				WORKFG);
				
				int Severity = result.Value;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ApsGetSHIFTEXDISp(int? AltNo,
		[Optional] string ResID,
		[Optional] string Filter)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ApsGetSHIFTEXDIExt = new CLM_ApsGetSHIFTEXDIFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ApsGetSHIFTEXDIExt.CLM_ApsGetSHIFTEXDISp(AltNo,
				ResID,
				Filter);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MO_SHIFTEXDIMaintIDQuerySp(string SHIFTEXID,
		ref string MaintenanceID,
		ref DateTime? StartDate,
		ref DateTime? EndDate,
		ref string SHIFTID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iMO_SHIFTEXDIMaintIDQueryExt = new MO_SHIFTEXDIMaintIDQueryFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iMO_SHIFTEXDIMaintIDQueryExt.MO_SHIFTEXDIMaintIDQuerySp(SHIFTEXID,
				MaintenanceID,
				StartDate,
				EndDate,
				SHIFTID);
				
				int Severity = result.ReturnCode.Value;
				MaintenanceID = result.MaintenanceID;
				StartDate = result.StartDate;
				EndDate = result.EndDate;
				SHIFTID = result.SHIFTID;
				return Severity;
			}
		}
    }
}
