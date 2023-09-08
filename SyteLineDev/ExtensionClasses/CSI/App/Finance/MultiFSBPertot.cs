//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBPertot.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBPertot
    {
        int MultiFSBPertotSp(SortMethodType BegSort,
                             SortMethodType EndSort,
                             ListYesNoType ActiveOnly,
                             FSBNameType FSBName,
                             ref InfobarType Infobar);
    }

    public class MultiFSBPertot : IMultiFSBPertot
    {
        readonly IApplicationDB appDB;

        public MultiFSBPertot(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBPertotSp(SortMethodType BegSort,
                                    SortMethodType EndSort,
                                    ListYesNoType ActiveOnly,
                                    FSBNameType FSBName,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBPertotSp";

                appDB.AddCommandParameter(cmd, "BegSort", BegSort, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndSort", EndSort, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ActiveOnly", ActiveOnly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}