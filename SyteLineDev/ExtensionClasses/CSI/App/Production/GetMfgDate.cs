//PROJECT NAME: CSIProduct
//CLASS NAME: GetMfgDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IGetMfgDate
    {
        int GetMfgDateSp(StringType DateLabel,
                         DateType RequestDate,
                         ref DateType McalDate,
                         ref InfobarType Infobar);
    }

    public class GetMfgDate : IGetMfgDate
    {
        readonly IApplicationDB appDB;

        public GetMfgDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetMfgDateSp(StringType DateLabel,
                                DateType RequestDate,
                                ref DateType McalDate,
                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMfgDateSp";

                appDB.AddCommandParameter(cmd, "DateLabel", DateLabel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RequestDate", RequestDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "McalDate", McalDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
