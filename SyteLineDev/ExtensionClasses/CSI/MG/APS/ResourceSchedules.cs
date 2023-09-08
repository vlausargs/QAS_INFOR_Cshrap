//PROJECT NAME: APSExt
//CLASS NAME: ResourceSchedules.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.APS;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.APS
{
    [IDOExtensionClass("ResourceSchedules")]
    public class ResourceSchedules : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ApsFreezeSchedOpSp(string OrderID,
                                      byte? FreezeFg,
                                      int? JOBTAG)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iApsFreezeSchedOpExt = new ApsFreezeSchedOpFactory().Create(appDb);

                int Severity = iApsFreezeSchedOpExt.ApsFreezeSchedOpSp(OrderID,
                                                                       FreezeFg,
                                                                       JOBTAG);

                return Severity;
            }
        }









		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsGanttGetJobOrdNumSp(string Job,
		                                  [Optional] short? Suffix,
		                                  ref string CoNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsGanttGetJobOrdNumExt = new ApsGanttGetJobOrdNumFactory().Create(appDb);
				
				var result = iApsGanttGetJobOrdNumExt.ApsGanttGetJobOrdNumSp(Job,
				                                                             Suffix,
				                                                             CoNum);
				
				int Severity = result.ReturnCode.Value;
				CoNum = result.CoNum;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsGanttValidateEditOperationSp([Optional, DefaultParameterValue((short)0)] short? AltNum,
		int? Plan0Sched1,
		string JSID,
		int? JobTag,
		int? SeqNum,
		string FromResource,
		DateTime? FromStartDate,
		DateTime? FromEndDate,
		string ToResource,
		DateTime? ToStartDate,
		DateTime? ToEndDate,
		ref string PromptMsg,
		ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iApsGanttValidateEditOperationExt = new ApsGanttValidateEditOperationFactory().Create(appDb);
				
				var result = iApsGanttValidateEditOperationExt.ApsGanttValidateEditOperationSp(AltNum,
				                                                                               Plan0Sched1,
				                                                                               JSID,
				                                                                               JobTag,
				                                                                               SeqNum,
				                                                                               FromResource,
				                                                                               FromStartDate,
				                                                                               FromEndDate,
				                                                                               ToResource,
				                                                                               ToStartDate,
				                                                                               ToEndDate,
				                                                                               PromptMsg,
				                                                                               PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ResourceGroupScheduleSp(DateTime? StartDate,
		                                             DateTime? EndDate,
		                                             [Optional, DefaultParameterValue((short)0)] short? AltNum,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ResourceGroupScheduleExt = new CLM_ResourceGroupScheduleFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ResourceGroupScheduleExt.CLM_ResourceGroupScheduleSp(StartDate,
				                                                                       EndDate,
				                                                                       AltNum,
				                                                                       FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ResourceScheduleSp(DateTime? StartDate,
		                                        DateTime? EndDate,
		                                        [Optional, DefaultParameterValue((short)0)] short? AltNum,
		[Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCLM_ResourceScheduleExt = new CLM_ResourceScheduleFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCLM_ResourceScheduleExt.CLM_ResourceScheduleSp(StartDate,
				                                                             EndDate,
				                                                             AltNum,
				                                                             FilterString);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetResGroupNumMemb(string ResourceGroupId,
		                              ref int? NumOfMembers)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetResGroupNumMembExt = new GetResGroupNumMembFactory().Create(appDb);
				
				var result = iGetResGroupNumMembExt.GetResGroupNumMembSp(ResourceGroupId,
				                                                         NumOfMembers);
				
				int Severity = result.ReturnCode.Value;
				NumOfMembers = result.NumOfMembers;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DateConvert(string DatePart,
		int? Number,
		ref DateTime? DateToChange,
		ref DateTime? ConvertedDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDateConvertExt = new DateConvertFactory().Create(appDb);
				
				var result = iDateConvertExt.DateConvertSp(DatePart,
				Number,
				DateToChange,
				ConvertedDate);
				
				int Severity = result.ReturnCode.Value;
				DateToChange = result.DateToChange;
				ConvertedDate = result.ConvertedDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetAlternDates(ref DateTime? StartDate,
		ref DateTime? EndDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetAlternDatesExt = new GetAlternDatesFactory().Create(appDb);
				
				var result = iGetAlternDatesExt.GetAlternDatesSp(StartDate,
				EndDate);
				
				int Severity = result.ReturnCode.Value;
				StartDate = result.StartDate;
				EndDate = result.EndDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ApsUpdateResSchedSp(string EditCode,
		string ResourceID,
		string GroupID,
		DateTime? StartDate,
		string StartCode,
		DateTime? EndDate,
		string EndCode,
		int? Jobtag,
		int? Seqnum,
		string StatusCode,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iApsUpdateResSchedExt = new ApsUpdateResSchedFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iApsUpdateResSchedExt.ApsUpdateResSchedSp(EditCode,
				ResourceID,
				GroupID,
				StartDate,
				StartCode,
				EndDate,
				EndCode,
				Jobtag,
				Seqnum,
				StatusCode,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Home_ResourceScheduleSp(DateTime? StartDate,
		DateTime? EndDate,
		[Optional, DefaultParameterValue(0)] int? AltNum,
		[Optional] string FilterString,
		string SiteGroup)
		{
			var iHome_ResourceScheduleExt = new Home_ResourceScheduleFactory().Create(this, true);
			
			var result = iHome_ResourceScheduleExt.Home_ResourceScheduleSp(StartDate,
			EndDate,
			AltNum,
			FilterString,
			SiteGroup);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ResGanttScheduleSp(DateTime? StartDate,
		DateTime? EndDate,
		[Optional, DefaultParameterValue(0)] int? AltNum,
		[Optional] string FilterString,
		[Optional] string CustNum,
		[Optional] string Item,
		[Optional] string Material)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ResGanttScheduleExt = new CLM_ResGanttScheduleFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ResGanttScheduleExt.CLM_ResGanttScheduleSp(StartDate,
				EndDate,
				AltNum,
				FilterString,
				CustNum,
				Item,
				Material);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetMinStartDateSp(ref DateTime? StartDate)
        {
            var iGetMinStartDateExt = new GetMinStartDateFactory().Create(this, true);

            var result = iGetMinStartDateExt.GetMinStartDateSp(StartDate);

            StartDate = result.StartDate;

            return result.ReturnCode ?? 0;
        }
    }
}
