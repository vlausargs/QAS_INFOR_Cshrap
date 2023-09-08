//PROJECT NAME: CSIDataCollection
//CLASS NAME: DctaAddValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDctaAddValidate
    {
        int DctaAddValidateSp(RowPointerType PRowPointer,
                              ref DcTransTypeType PTransType,
                              ref TimeSecondsType PTransTime,
                              ref InfobarType Infobar);
    }

    public class DctaAddValidate : IDctaAddValidate
    {
        readonly IApplicationDB appDB;

        public DctaAddValidate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DctaAddValidateSp(RowPointerType PRowPointer,
                                     ref DcTransTypeType PTransType,
                                     ref TimeSecondsType PTransTime,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DctaAddValidateSp";

                appDB.AddCommandParameter(cmd, "PRowPointer", PRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTransType", PTransType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PTransTime", PTransTime, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

