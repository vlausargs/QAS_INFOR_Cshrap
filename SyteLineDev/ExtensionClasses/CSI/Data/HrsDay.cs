//PROJECT NAME: Data
//CLASS NAME: HrsDay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data
{
    public class HrsDay : IHrsDay
    {
        readonly IApplicationDB appDB;

        public HrsDay(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
            decimal? HrsPerDay,
            string Infobar) HrsDaySp(
            string PShiftID,
            DateTime? PDate,
            decimal? HrsPerDay,
            string Infobar)
        {
            ApsShiftType _PShiftID = PShiftID;
            CurrentDateType _PDate = PDate;
            GenericDecimalType _HrsPerDay = HrsPerDay;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "HrsDaySp";

                appDB.AddCommandParameter(cmd, "PShiftID", _PShiftID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                HrsPerDay = _HrsPerDay;
                Infobar = _Infobar;

                return (Severity, HrsPerDay, Infobar);
            }
        }
    }
}
