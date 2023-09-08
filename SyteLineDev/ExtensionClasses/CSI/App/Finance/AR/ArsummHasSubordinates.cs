//PROJECT NAME: CSICustomer
//CLASS NAME: ArsummHasSubordinates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IArsummHasSubordinates
    {
        int ArsummHasSubordinatesSp(CustNumType PCustNum,
                                    ref ListYesNoType PSubordinate,
                                    ref InfobarType Infobar);
    }

    public class ArsummHasSubordinates : IArsummHasSubordinates
    {
        readonly IApplicationDB appDB;

        public ArsummHasSubordinates(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ArsummHasSubordinatesSp(CustNumType PCustNum,
                                           ref ListYesNoType PSubordinate,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ArsummHasSubordinatesSp";

                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSubordinate", PSubordinate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
