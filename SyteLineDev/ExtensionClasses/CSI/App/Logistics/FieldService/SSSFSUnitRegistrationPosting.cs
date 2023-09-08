//PROJECT NAME: CSIFSPlus
//CLASS NAME: SSSFSUnitRegistrationPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSUnitRegistrationPosting
    {
        int SSSFSUnitRegistrationPostingSP(HugeTransNumType TransNum,
                                           ref InfobarType Infobar);
    }

    public class SSSFSUnitRegistrationPosting : ISSSFSUnitRegistrationPosting
    {
        readonly IApplicationDB appDB;

        public SSSFSUnitRegistrationPosting(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSUnitRegistrationPostingSP(HugeTransNumType TransNum,
                                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSUnitRegistrationPostingSP";

                appDB.AddCommandParameter(cmd, "TransNum", TransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
