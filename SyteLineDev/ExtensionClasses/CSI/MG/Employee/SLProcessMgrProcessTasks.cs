//PROJECT NAME: EmployeeExt
//CLASS NAME: SLProcessMgrProcessTasks.cs

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
    [IDOExtensionClass("SLProcessMgrProcessTasks")]
    public class SLProcessMgrProcessTasks : ExtensionClassBase
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MarkProMgrMyTaskStateSp(Guid? RowPointer,
                                           string UserName)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iMarkProMgrMyTaskStateExt = new MarkProMgrMyTaskStateFactory().Create(appDb);

                int Severity = iMarkProMgrMyTaskStateExt.MarkProMgrMyTaskStateSp(RowPointer,
                                                                                 UserName);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PMMyTaskAttachSyncSp(Guid? RowPointer)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPMMyTaskAttachSyncExt = new PMMyTaskAttachSyncFactory().Create(appDb);

                int Severity = iPMMyTaskAttachSyncExt.PMMyTaskAttachSyncSp(RowPointer);

                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GenericNotifyEventGlobalCsSp(string EventGlobalConstant,
		                                        [Optional] Guid? ProcessTaskRowPointer,
		                                        [Optional] ref Guid? EventStateRowPointer,
		                                        [Optional] ref string Infobar,
		                                        [Optional] string ParmName1,
		                                        [Optional] string ParmValue1,
		                                        [Optional] string ParmName2,
		                                        [Optional] string ParmValue2,
		                                        [Optional] string ParmName3,
		                                        [Optional] string ParmValue3,
		                                        [Optional] string ParmName4,
		                                        [Optional] string ParmValue4,
		                                        [Optional] string ParmName5,
		                                        [Optional] string ParmValue5,
		                                        [Optional] string ParmName6,
		                                        [Optional] string ParmValue6,
		                                        [Optional] string ParmName7,
		                                        [Optional] string ParmValue7,
		                                        [Optional] string ParmName8,
		                                        [Optional] string ParmValue8,
		                                        [Optional] string ParmName9,
		                                        [Optional] string ParmValue9,
		                                        [Optional] string ParmName10,
		                                        [Optional] string ParmValue10,
		                                        [Optional] string ParmName11,
		                                        [Optional] string ParmValue11,
		                                        [Optional] string ParmName12,
		                                        [Optional] string ParmValue12,
		                                        [Optional] string ParmName13,
		                                        [Optional] string ParmValue13,
		                                        [Optional] string ParmName14,
		                                        [Optional] string ParmValue14,
		                                        [Optional] string ParmName15,
		                                        [Optional] string ParmValue15,
		                                        [Optional] string ParmName16,
		                                        [Optional] string ParmValue16,
		                                        [Optional] string ParmName17,
		                                        [Optional] string ParmValue17,
		                                        [Optional] string ParmName18,
		                                        [Optional] string ParmValue18,
		                                        [Optional] string ParmName19,
		                                        [Optional] string ParmValue19,
		                                        [Optional] string ParmName20,
		                                        [Optional] string ParmValue20)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGenericNotifyEventGlobalCsExt = new GenericNotifyEventGlobalCsFactory().Create(appDb);
				
				var result = iGenericNotifyEventGlobalCsExt.GenericNotifyEventGlobalCsSp(EventGlobalConstant,
				                                                                         ProcessTaskRowPointer,
				                                                                         EventStateRowPointer,
				                                                                         Infobar,
				                                                                         ParmName1,
				                                                                         ParmValue1,
				                                                                         ParmName2,
				                                                                         ParmValue2,
				                                                                         ParmName3,
				                                                                         ParmValue3,
				                                                                         ParmName4,
				                                                                         ParmValue4,
				                                                                         ParmName5,
				                                                                         ParmValue5,
				                                                                         ParmName6,
				                                                                         ParmValue6,
				                                                                         ParmName7,
				                                                                         ParmValue7,
				                                                                         ParmName8,
				                                                                         ParmValue8,
				                                                                         ParmName9,
				                                                                         ParmValue9,
				                                                                         ParmName10,
				                                                                         ParmValue10,
				                                                                         ParmName11,
				                                                                         ParmValue11,
				                                                                         ParmName12,
				                                                                         ParmValue12,
				                                                                         ParmName13,
				                                                                         ParmValue13,
				                                                                         ParmName14,
				                                                                         ParmValue14,
				                                                                         ParmName15,
				                                                                         ParmValue15,
				                                                                         ParmName16,
				                                                                         ParmValue16,
				                                                                         ParmName17,
				                                                                         ParmValue17,
				                                                                         ParmName18,
				                                                                         ParmValue18,
				                                                                         ParmName19,
				                                                                         ParmValue19,
				                                                                         ParmName20,
				                                                                         ParmValue20);
				
				int Severity = result.ReturnCode.Value;
				EventStateRowPointer = result.EventStateRowPointer;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SaveTaskforFutureProcessesSp(string Type,
		                                        string Name,
		                                        string Descr,
		                                        short? DateOffset,
		                                        string FormName,
		                                        string EventName,
		                                        ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSaveTaskforFutureProcessesExt = new SaveTaskforFutureProcessesFactory().Create(appDb);
				
				var result = iSaveTaskforFutureProcessesExt.SaveTaskforFutureProcessesSp(Type,
				                                                                         Name,
				                                                                         Descr,
				                                                                         DateOffset,
				                                                                         FormName,
				                                                                         EventName,
				                                                                         Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ProcessMgrProcessTaskSp(decimal? ProcessId,
		DateTime? DueDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ProcessMgrProcessTaskExt = new CLM_ProcessMgrProcessTaskFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ProcessMgrProcessTaskExt.CLM_ProcessMgrProcessTaskSp(ProcessId,
				DueDate);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
