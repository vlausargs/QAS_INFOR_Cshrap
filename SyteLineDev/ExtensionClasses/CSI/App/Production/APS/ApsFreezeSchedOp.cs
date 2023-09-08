//PROJECT NAME: CSIAPS
//CLASS NAME: ApsFreezeSchedOp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsFreezeSchedOp
    {
        int ApsFreezeSchedOpSp(ApsOrderType OrderID,
                               ListYesNoType FreezeFg,
                               ApsOperationTagType JOBTAG);
    }

    public class ApsFreezeSchedOp : IApsFreezeSchedOp
    {
        readonly IApplicationDB appDB;

        public ApsFreezeSchedOp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsFreezeSchedOpSp(ApsOrderType OrderID,
                                      ListYesNoType FreezeFg,
                                      ApsOperationTagType JOBTAG)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsFreezeSchedOpSp";

                appDB.AddCommandParameter(cmd, "OrderID", OrderID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FreezeFg", FreezeFg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JOBTAG", JOBTAG, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
