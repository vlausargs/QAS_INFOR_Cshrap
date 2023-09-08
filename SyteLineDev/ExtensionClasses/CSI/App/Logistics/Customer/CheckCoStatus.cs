//PROJECT NAME: CSICustomer
//CLASS NAME: CheckCoStatus.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICheckCoStatus
    {
        int CheckCoStatusSp(CoTypeType CoType,
                            LongListType CoNumListToCheck,
                            ref LongListType CoNumAndStatList,
                            ref Infobar Infobar);
    }

    public class CheckCoStatus : ICheckCoStatus
    {
        readonly IApplicationDB appDB;

        public CheckCoStatus(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckCoStatusSp(CoTypeType CoType,
                                   LongListType CoNumListToCheck,
                                   ref LongListType CoNumAndStatList,
                                   ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckCoStatusSp";

                appDB.AddCommandParameter(cmd, "CoType", CoType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNumListToCheck", CoNumListToCheck, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNumAndStatList", CoNumAndStatList, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
