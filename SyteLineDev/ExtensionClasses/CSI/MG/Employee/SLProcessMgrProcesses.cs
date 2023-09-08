//PROJECT NAME: EmployeeExt
//CLASS NAME: SLProcessMgrProcesses.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Employee;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Employee
{
    [IDOExtensionClass("SLProcessMgrProcesses")]
    public class SLProcessMgrProcesses : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ProcessMgrProcessSp(string StartProcesstype,
                                                 string EndProcesstype,
                                                 string StartPorcessName,
                                                 string EndPorcessName,
                                                 string StartUsername,
                                                 string EndUsername,
                                                 string StartEmpNum,
                                                 string EndEmpNum,
                                                 string StartTemplatetype,
                                                 string EndTemplatetype,
                                                 string StartTemplateName,
                                                 string EndTemplateName,
                                                 string DeleteFlag,
                                                 string PreviewOrCommit,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iCLM_ProcessMgrProcessExt = new CLM_ProcessMgrProcessFactory().Create(appDb, bunchedLoadCollection);

                InfobarType oInfobar = Infobar;

                DataTable dt = iCLM_ProcessMgrProcessExt.CLM_ProcessMgrProcessSp(StartProcesstype,
                                                                                 EndProcesstype,
                                                                                 StartPorcessName,
                                                                                 EndPorcessName,
                                                                                 StartUsername,
                                                                                 EndUsername,
                                                                                 StartEmpNum,
                                                                                 EndEmpNum,
                                                                                 StartTemplatetype,
                                                                                 EndTemplatetype,
                                                                                 StartTemplateName,
                                                                                 EndTemplateName,
                                                                                 DeleteFlag,
                                                                                 PreviewOrCommit,
                                                                                 ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int InitProcessEmailSp(decimal? Id,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iInitProcessEmailExt = new InitProcessEmailFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iInitProcessEmailExt.InitProcessEmailSp(Id,
                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PMTAttachFromTempSp(Guid? RowPointer,
                                       string PmpName)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPMTAttachFromTempExt = new PMTAttachFromTempFactory().Create(appDb);

                int Severity = iPMTAttachFromTempExt.PMTAttachFromTempSp(RowPointer,
                                                                         PmpName);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RemindAssigneeSendEmailSp(decimal? ProcessId,
                                             short? TaskNum,
                                             ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRemindAssigneeSendEmailExt = new RemindAssigneeSendEmailFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iRemindAssigneeSendEmailExt.RemindAssigneeSendEmailSp(ProcessId,
                                                                                     TaskNum,
                                                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int RemindUpdateSendEmailSp(decimal? ProcessId,
                                           string UserName,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iRemindUpdateSendEmailExt = new RemindUpdateSendEmailFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iRemindUpdateSendEmailExt.RemindUpdateSendEmailSp(ProcessId,
                                                                                 UserName,
                                                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ProcessSaveAsTemplateSp([Optional] Guid? ProcessRowPointer,
		                                   [Optional] string job_id,
		                                   [Optional] string dept,
		                                   [Optional] string div_num,
		                                   ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iProcessSaveAsTemplateExt = new ProcessSaveAsTemplateFactory().Create(appDb);
				
				var result = iProcessSaveAsTemplateExt.ProcessSaveAsTemplateSp(ProcessRowPointer,
				                                                               job_id,
				                                                               dept,
				                                                               div_num,
				                                                               Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateProcessStatusSp([Optional] decimal? ProcessId,
		[Optional] string CurrentProcessStat,
		[Optional] string OriginalProcessStat,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateProcessStatusExt = new ValidateProcessStatusFactory().Create(appDb);
				
				var result = iValidateProcessStatusExt.ValidateProcessStatusSp(ProcessId,
				CurrentProcessStat,
				OriginalProcessStat,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_ProcessMgrUserSp()
        {
            var iCLM_ProcessMgrUserExt = this.GetService<ICLM_ProcessMgrUser>();

            var result = iCLM_ProcessMgrUserExt.CLM_ProcessMgrUserSp();

            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
            }
        }
    }
}
