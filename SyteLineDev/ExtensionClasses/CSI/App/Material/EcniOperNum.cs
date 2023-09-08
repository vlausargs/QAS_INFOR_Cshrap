//PROJECT NAME: CSIMaterial
//CLASS NAME: EcniOperNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IEcniOperNum
    {
        int EcniOperNumSp(EcnitemTypeType PEcnitemType,
                          JobType PJob,
                          SuffixType PSuffix,
                          OperNumType POperNum,
                          RecordActionType PActionCode,
                          ItemType PItem,
                          ref InfobarType Infobar);
    }

    public class EcniOperNum : IEcniOperNum
    {
        readonly IApplicationDB appDB;

        public EcniOperNum(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EcniOperNumSp(EcnitemTypeType PEcnitemType,
                                 JobType PJob,
                                 SuffixType PSuffix,
                                 OperNumType POperNum,
                                 RecordActionType PActionCode,
                                 ItemType PItem,
                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EcniOperNumSp";

                appDB.AddCommandParameter(cmd, "PEcnitemType", PEcnitemType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POperNum", POperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PActionCode", PActionCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
