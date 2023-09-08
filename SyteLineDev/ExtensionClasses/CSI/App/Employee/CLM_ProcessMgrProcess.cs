//PROJECT NAME: CSIEmployee
//CLASS NAME: CLM_ProcessMgrProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface ICLM_ProcessMgrProcess
    {
        DataTable CLM_ProcessMgrProcessSp(ProcessManagerProcessTypeType StartProcesstype,
                                          ProcessManagerProcessTypeType EndProcesstype,
                                          NameType StartPorcessName,
                                          NameType EndPorcessName,
                                          UsernameType StartUsername,
                                          UsernameType EndUsername,
                                          EmpNumType StartEmpNum,
                                          EmpNumType EndEmpNum,
                                          ProcessManagerProcessTypeType StartTemplatetype,
                                          ProcessManagerProcessTypeType EndTemplatetype,
                                          NameType StartTemplateName,
                                          NameType EndTemplateName,
                                          StringType DeleteFlag,
                                          StringType PreviewOrCommit,
                                          ref InfobarType Infobar);
    }

    public class CLM_ProcessMgrProcess : ICLM_ProcessMgrProcess
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ProcessMgrProcess(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ProcessMgrProcessSp(ProcessManagerProcessTypeType StartProcesstype,
                                                 ProcessManagerProcessTypeType EndProcesstype,
                                                 NameType StartPorcessName,
                                                 NameType EndPorcessName,
                                                 UsernameType StartUsername,
                                                 UsernameType EndUsername,
                                                 EmpNumType StartEmpNum,
                                                 EmpNumType EndEmpNum,
                                                 ProcessManagerProcessTypeType StartTemplatetype,
                                                 ProcessManagerProcessTypeType EndTemplatetype,
                                                 NameType StartTemplateName,
                                                 NameType EndTemplateName,
                                                 StringType DeleteFlag,
                                                 StringType PreviewOrCommit,
                                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CLM_ProcessMgrProcessSp";

                appDB.AddCommandParameter(cmd, "StartProcesstype", StartProcesstype, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProcesstype", EndProcesstype, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartPorcessName", StartPorcessName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndPorcessName", EndPorcessName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartUsername", StartUsername, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndUsername", EndUsername, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartEmpNum", StartEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndEmpNum", EndEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartTemplatetype", StartTemplatetype, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndTemplatetype", EndTemplatetype, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartTemplateName", StartTemplateName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndTemplateName", EndTemplateName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DeleteFlag", DeleteFlag, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PreviewOrCommit", PreviewOrCommit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
