using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG.MGCore;
using CSI.MG;

namespace CSI.Data.SQL
{
    public class MidnightOf : IMidnightOf
    {
        IApplicationDB appDB;


        public MidnightOf(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public DateTime? MidnightOfFn(DateTime? Date)
        {
            if (Date == null)
                return Date;

            var date = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 0, 0, 0);

            return date;
        }

        public DateTime? MidnightOfSp(DateTime? Date)
        {
            DateTimeType _Date = Date;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[MidnightOfSp](@Date)";

                appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<DateTime?>(cmd);

                return Output;
            }
        }
    }
}
