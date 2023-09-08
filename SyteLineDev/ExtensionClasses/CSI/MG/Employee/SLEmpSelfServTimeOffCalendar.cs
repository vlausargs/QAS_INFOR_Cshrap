//PROJECT NAME: EmployeeExt
//CLASS NAME: SLEmpSelfServTimeOffCalendar.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLEmpSelfServTimeOffCalendar")]
    public class SLEmpSelfServTimeOffCalendar : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetEmpSelfServInfoSp(ref string EmpNum,
                                ref DateTime? Today,
                                ref DateTime? FirstDayOfCurrentYear)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetEmpSelfServInfoExt = new GetEmpSelfServInfoFactory().Create(appDb);

                EmpNumType oEmpNum = EmpNum;
                DateType oToday = Today;
                DateType oFirstDayOfCurrentYear = FirstDayOfCurrentYear;

                int Severity = iGetEmpSelfServInfoExt.GetEmpSelfServInfoSp(ref oEmpNum,
                                                                           ref oToday,
                                                                           ref oFirstDayOfCurrentYear);

                EmpNum = oEmpNum;
                Today = oToday;
                FirstDayOfCurrentYear = oFirstDayOfCurrentYear;


                return Severity;
            }
        }







		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApproveTimeOffRequestSp(string EmpNum,
		                                   DateTime? TimeOffStartDate,
		                                   DateTime? TimeOffEndDate,
		                                   [Optional] string TimeOffManagerComments,
		                                   ref string Inforbar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApproveTimeOffRequestExt = new ApproveTimeOffRequestFactory().Create(appDb);
				
				var result = iApproveTimeOffRequestExt.ApproveTimeOffRequestSp(EmpNum,
				                                                               TimeOffStartDate,
				                                                               TimeOffEndDate,
				                                                               TimeOffManagerComments,
				                                                               Inforbar);
				
				int Severity = result.ReturnCode.Value;
				Inforbar = result.Inforbar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CreateTimeOffRequestSp(string EmpNum,
		                                  DateTime? TimeOffStartDate,
		                                  DateTime? TimeOffEndDate,
		                                  string ReasonCode,
		                                  decimal? TimeOffHours,
		                                  [Optional] string TimeOffEmpComments,
		                                  ref string Inforbar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iCreateTimeOffRequestExt = new CreateTimeOffRequestFactory().Create(appDb);
				
				var result = iCreateTimeOffRequestExt.CreateTimeOffRequestSp(EmpNum,
				                                                             TimeOffStartDate,
				                                                             TimeOffEndDate,
				                                                             ReasonCode,
				                                                             TimeOffHours,
				                                                             TimeOffEmpComments,
				                                                             Inforbar);
				
				int Severity = result.ReturnCode.Value;
				Inforbar = result.Inforbar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ESSGetSupNameSp([Optional] string EmpNum,
		                           ref string SupName)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iESSGetSupNameExt = new ESSGetSupNameFactory().Create(appDb);
				
				var result = iESSGetSupNameExt.ESSGetSupNameSp(EmpNum,
				                                               SupName);
				
				int Severity = result.ReturnCode.Value;
				SupName = result.SupName;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESSGetEmpInfoSp([Optional] string EmpNum,
		[Optional] string UserName,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESSGetEmpInfoExt = new CLM_ESSGetEmpInfoFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESSGetEmpInfoExt.CLM_ESSGetEmpInfoSp(EmpNum,
				UserName,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				Infobar = result.Infobar;
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESSPopulateTimeOffCalendarSp(string EmpNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESSPopulateTimeOffCalendarExt = new CLM_ESSPopulateTimeOffCalendarFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESSPopulateTimeOffCalendarExt.CLM_ESSPopulateTimeOffCalendarSp(EmpNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ESSTeamTimeOffSp(string EmpNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ESSTeamTimeOffExt = new CLM_ESSTeamTimeOffFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ESSTeamTimeOffExt.CLM_ESSTeamTimeOffSp(EmpNum);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RejectTimeOffRequestSp(string EmpNum,
		DateTime? TimeOffStartDate,
		DateTime? TimeOffEndDate,
		[Optional] string TimeOffManagerComments,
		ref string Inforbar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRejectTimeOffRequestExt = new RejectTimeOffRequestFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRejectTimeOffRequestExt.RejectTimeOffRequestSp(EmpNum,
				TimeOffStartDate,
				TimeOffEndDate,
				TimeOffManagerComments,
				Inforbar);
				
				int Severity = result.ReturnCode.Value;
				Inforbar = result.Inforbar;
				return Severity;
			}
		}
    }
}
