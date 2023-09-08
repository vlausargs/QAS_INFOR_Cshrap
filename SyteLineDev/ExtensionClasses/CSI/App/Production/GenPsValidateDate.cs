//PROJECT NAME: CSIProduct
//CLASS NAME: GenPsValidateDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IGenPsValidateDate
    {
        int GenPsValidateDateSp(ref DateType FromDate,
                                ref DateType EndDate,
                                ref DateType MDate,
                                ref MdayNumType MdayNum,
                                ref InfobarType Infobar);
    }

    public class GenPsValidateDate : IGenPsValidateDate
    {
        readonly IApplicationDB appDB;

        public GenPsValidateDate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GenPsValidateDateSp(ref DateType FromDate,
                                       ref DateType EndDate,
                                       ref DateType MDate,
                                       ref MdayNumType MdayNum,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GenPsValidateDateSp";

                appDB.AddCommandParameter(cmd, "FromDate", FromDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EndDate", EndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MDate", MDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MdayNum", MdayNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
