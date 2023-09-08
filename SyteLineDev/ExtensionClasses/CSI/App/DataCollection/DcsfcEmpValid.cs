//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcEmpValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDcsfcEmpValid
    {
        int DcsfcEmpValidSp(EmpNumType EmpNum,
                            DcsfcTransTypeType TransType,
                            DcsfcTransTypeType OldTransType,
                            DcStatusType TransStat,
                            ref PayRateType OutPrRate,
                            ref PayRateType OutJobRate,
                            ref IndCodeType OutIndCode,
                            ref InfobarType Infobar);
    }

    public class DcsfcEmpValid : IDcsfcEmpValid
    {
        readonly IApplicationDB appDB;

        public DcsfcEmpValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DcsfcEmpValidSp(EmpNumType EmpNum,
                                   DcsfcTransTypeType TransType,
                                   DcsfcTransTypeType OldTransType,
                                   DcStatusType TransStat,
                                   ref PayRateType OutPrRate,
                                   ref PayRateType OutJobRate,
                                   ref IndCodeType OutIndCode,
                                   ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DcsfcEmpValidSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransType", TransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldTransType", OldTransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransStat", TransStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutPrRate", OutPrRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutJobRate", OutJobRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutIndCode", OutIndCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

