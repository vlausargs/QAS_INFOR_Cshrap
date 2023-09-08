//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranTransTypeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobtranTransTypeValid
    {
        int JobtranTransTypeValidSp(JobtranTypeType InTransType,
                                    JobType InJob,
                                    SuffixType InSuffix,
                                    DateType InTransDate,
                                    EmpNumType InEmpNum,
                                    ShiftType InShift,
                                    HugeTransNumType InTransNum,
                                    ref EmpNumType OutEmpNum,
                                    ref ShiftType OutShift,
                                    ref PayBasisType OutPayRate,
                                    ref PayRateType OutPrRate,
                                    ref PayRateType OutJobRate,
                                    ref JobType OutJob,
                                    ref SuffixType OutSuffix,
                                    ref OperNumType OutOperNum,
                                    ref CoProductMixType OutCoProductMix,
                                    ref NameType OutEmpName);
    }

    public class JobtranTransTypeValid : IJobtranTransTypeValid
    {
        readonly IApplicationDB appDB;

        public JobtranTransTypeValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobtranTransTypeValidSp(JobtranTypeType InTransType,
                                           JobType InJob,
                                           SuffixType InSuffix,
                                           DateType InTransDate,
                                           EmpNumType InEmpNum,
                                           ShiftType InShift,
                                           HugeTransNumType InTransNum,
                                           ref EmpNumType OutEmpNum,
                                           ref ShiftType OutShift,
                                           ref PayBasisType OutPayRate,
                                           ref PayRateType OutPrRate,
                                           ref PayRateType OutJobRate,
                                           ref JobType OutJob,
                                           ref SuffixType OutSuffix,
                                           ref OperNumType OutOperNum,
                                           ref CoProductMixType OutCoProductMix,
                                           ref NameType OutEmpName)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobtranTransTypeValidSp";

                appDB.AddCommandParameter(cmd, "InTransType", InTransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InTransDate", InTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InEmpNum", InEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InShift", InShift, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InTransNum", InTransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutEmpNum", OutEmpNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutShift", OutShift, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutPayRate", OutPayRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutPrRate", OutPrRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutJobRate", OutJobRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutJob", OutJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutSuffix", OutSuffix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutOperNum", OutOperNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutCoProductMix", OutCoProductMix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutEmpName", OutEmpName, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
