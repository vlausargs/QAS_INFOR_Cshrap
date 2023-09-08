//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionVfyJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IEmpPositionVfyJob
    {
        int EmpPositionVfyJobSp(JobIdType PJobId,
                                JobDetailType PJobDetail,
                                ref DeptType TDept,
                                ref DivNumType TDiv,
                                ref CompNumType TCompNum,
                                ref JobTitleType TJobTitle,
                                ref EmpNumType TSuperNum,
                                ref PosClassType TClass,
                                ref JobGradeType TJobGrade,
                                ref EEOClsType TEeoCls,
                                ref ListYesNoType TExempt,
                                ref DeCodeType TWcClass,
                                ref DescriptionType TDeptDesc,
                                ref NameType TDivName,
                                ref NameType TCompName,
                                ref NameType TSuperName,
                                ref DescriptionType TWcDescDesc,
                                ref InfobarType Infobar);
    }

    public class EmpPositionVfyJob : IEmpPositionVfyJob
    {
        readonly IApplicationDB appDB;

        public EmpPositionVfyJob(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EmpPositionVfyJobSp(JobIdType PJobId,
                                       JobDetailType PJobDetail,
                                       ref DeptType TDept,
                                       ref DivNumType TDiv,
                                       ref CompNumType TCompNum,
                                       ref JobTitleType TJobTitle,
                                       ref EmpNumType TSuperNum,
                                       ref PosClassType TClass,
                                       ref JobGradeType TJobGrade,
                                       ref EEOClsType TEeoCls,
                                       ref ListYesNoType TExempt,
                                       ref DeCodeType TWcClass,
                                       ref DescriptionType TDeptDesc,
                                       ref NameType TDivName,
                                       ref NameType TCompName,
                                       ref NameType TSuperName,
                                       ref DescriptionType TWcDescDesc,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpPositionVfyJobSp";

                appDB.AddCommandParameter(cmd, "PJobId", PJobId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobDetail", PJobDetail, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TDept", TDept, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TDiv", TDiv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TCompNum", TCompNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TJobTitle", TJobTitle, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TSuperNum", TSuperNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TClass", TClass, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TJobGrade", TJobGrade, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TEeoCls", TEeoCls, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TExempt", TExempt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TWcClass", TWcClass, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TDeptDesc", TDeptDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TDivName", TDivName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TCompName", TCompName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TSuperName", TSuperName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TWcDescDesc", TWcDescDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
