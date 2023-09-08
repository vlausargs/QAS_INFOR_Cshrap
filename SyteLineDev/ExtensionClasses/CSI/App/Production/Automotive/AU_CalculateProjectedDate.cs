//PROJECT NAME: CSIAUIndPack
//CLASS NAME: AU_CalculateProjectedDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Automotive
{
    public interface IAU_CalculateProjectedDate
    {
        int AU_CalculateProjectedDateSp(AU_QAProcessIDType ProcessID,
                                        DateType StartDate,
                                        ref DateType ProjectedDate);
    }

    public class AU_CalculateProjectedDate : IAU_CalculateProjectedDate
    {
        readonly IApplicationDB appDB;

        public AU_CalculateProjectedDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_CalculateProjectedDateSp(AU_QAProcessIDType ProcessID,
                                               DateType StartDate,
                                               ref DateType ProjectedDate)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_CalculateProjectedDateSp";

                appDB.AddCommandParameter(cmd, "ProcessID", ProcessID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartDate", StartDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProjectedDate", ProjectedDate, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

