//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpUpdateDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpUpdateDueDate
    {
        int ApsCtpUpdateDueDateSp(CoNumType PCoNum,
                                  CoLineType PCoLine,
                                  DateType PDueDate);
    }

    public class ApsCtpUpdateDueDate : IApsCtpUpdateDueDate
    {
        readonly IApplicationDB appDB;

        public ApsCtpUpdateDueDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpUpdateDueDateSp(CoNumType PCoNum,
                                         CoLineType PCoLine,
                                         DateType PDueDate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpUpdateDueDateSp";

                appDB.AddCommandParameter(cmd, "PCoNum", PCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoLine", PCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDueDate", PDueDate, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
