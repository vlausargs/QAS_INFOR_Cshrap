//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctaP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDctaP
    {
        int DctaPSp(ref CurrentDateType PPostDate,
                    ref InfobarType Infobar);
    }

    public class DctaP : IDctaP
    {
        readonly IApplicationDB appDB;

        public DctaP(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DctaPSp(ref CurrentDateType PPostDate,
                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DctaPSp";

                appDB.AddCommandParameter(cmd, "PPostDate", PPostDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
