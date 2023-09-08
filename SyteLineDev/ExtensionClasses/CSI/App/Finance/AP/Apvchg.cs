//PROJECT NAME: CSIVendor
//CLASS NAME: Apvchg.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AP
{
    public interface IApvchg
    {
        int ApvchgSp(VendNumType SVendNum,
                     VendNumType EVendNum,
                     IntType PNewVoucherMonth,
                     IntType PNewVoucherYear,
                     DateType PDistDate,
                     ref InfobarType Infobar);
    }

    public class Apvchg : IApvchg
    {
        readonly IApplicationDB appDB;

        public Apvchg(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApvchgSp(VendNumType SVendNum,
                            VendNumType EVendNum,
                            IntType PNewVoucherMonth,
                            IntType PNewVoucherYear,
                            DateType PDistDate,
                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApvchgSp";

                appDB.AddCommandParameter(cmd, "SVendNum", SVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EVendNum", EVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PNewVoucherMonth", PNewVoucherMonth, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PNewVoucherYear", PNewVoucherYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDistDate", PDistDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
