//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcTransTypeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDcsfcTransTypeValid
    {
        int DcsfcTransTypeValidSp(DcsfcTransTypeType TransType,
                                  DcStatusType TransStat,
                                  ref InfobarType Infobar);
    }

    public class DcsfcTransTypeValid : IDcsfcTransTypeValid
    {
        readonly IApplicationDB appDB;

        public DcsfcTransTypeValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DcsfcTransTypeValidSp(DcsfcTransTypeType TransType,
                                         DcStatusType TransStat,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DcsfcTransTypeValidSp";

                appDB.AddCommandParameter(cmd, "TransType", TransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransStat", TransStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
