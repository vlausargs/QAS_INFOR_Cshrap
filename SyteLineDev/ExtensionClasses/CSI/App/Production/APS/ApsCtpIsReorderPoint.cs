//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsReorderPoint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpIsReorderPoint
    {
        int ApsCtpIsReorderPointSp(ItemType PItem,
                                   ref ListYesNoType PReorderPoint);
    }

    public class ApsCtpIsReorderPoint : IApsCtpIsReorderPoint
    {
        readonly IApplicationDB appDB;

        public ApsCtpIsReorderPoint(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpIsReorderPointSp(ItemType PItem,
                                          ref ListYesNoType PReorderPoint)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpIsReorderPointSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PReorderPoint", PReorderPoint, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
