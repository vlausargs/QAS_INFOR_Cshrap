//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtGetDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IAppmtGetDueDate
    {
        int AppmtGetDueDateSp(DateTime? PCheckDate,
                              string PVendNum,
                              ref DateTime? RDueDate,
                              ref string Infobar);
    }

    public class AppmtGetDueDate : IAppmtGetDueDate
    {
        readonly IApplicationDB appDB;

        public AppmtGetDueDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AppmtGetDueDateSp(DateTime? PCheckDate,
                                     string PVendNum,
                                     ref DateTime? RDueDate,
                                     ref string Infobar)
        {
            DateType _PCheckDate = PCheckDate;
            VendNumType _PVendNum = PVendNum;
            DateType _RDueDate = RDueDate;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AppmtGetDueDateSp";

                appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RDueDate", _RDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                RDueDate = _RDueDate;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}

