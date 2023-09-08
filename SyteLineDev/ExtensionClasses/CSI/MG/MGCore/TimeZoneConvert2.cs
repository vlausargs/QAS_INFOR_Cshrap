using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;

namespace CSI.MG.MGCore
{
	public class TimeZoneConvert2 : ITimeZoneConvert2
	{
		IApplicationDB appDB;


		public TimeZoneConvert2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

        public DateTime? TimeZoneConvert2Fn(DateTime? inDate,
        string fromTZ,
        string toTZ)
        {
            DateTimeType _inDate = inDate;
            TimeZoneType _fromTZ = fromTZ;
            TimeZoneType _toTZ = toTZ;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[TimeZoneConvert2](@inDate, @fromTZ, @toTZ)";

                appDB.AddCommandParameter(cmd, "inDate", _inDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "fromTZ", _fromTZ, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "toTZ", _toTZ, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<DateTime?>(cmd);

                return Output;
            }
        }
    }
}
