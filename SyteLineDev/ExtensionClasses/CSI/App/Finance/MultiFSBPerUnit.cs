//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBPerUnit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBPerUnit
    {
        int MultiFSBPerUnitSp(FSBNameType FSBName,
                              SortMethodType StartingSortMethod,
                              SortMethodType EndingSortMethod,
                              ref InfobarType Infobar);
    }

    public class MultiFSBPerUnit : IMultiFSBPerUnit
    {
        readonly IApplicationDB appDB;

        public MultiFSBPerUnit(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBPerUnitSp(FSBNameType FSBName,
                                     SortMethodType StartingSortMethod,
                                     SortMethodType EndingSortMethod,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBPerUnitSp";

                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingSortMethod", StartingSortMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingSortMethod", EndingSortMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}