//PROJECT NAME: Data
//CLASS NAME: AndSqlWhereWithISNULL.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class AndSqlWhereWithISNULL : IAndSqlWhereWithISNULL
    {
        readonly IApplicationDB appDB;

        public AndSqlWhereWithISNULL(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string AndSqlWhereWithISNULLFn(
            string TableAlias,
            string ColumnName,
            string NullValue,
            int? UseQuotes,
            string LowValue,
            string HighValue)
        {
            StringType _TableAlias = TableAlias;
            StringType _ColumnName = ColumnName;
            LongListType _NullValue = NullValue;
            ListYesNoType _UseQuotes = UseQuotes;
            LongListType _LowValue = LowValue;
            LongListType _HighValue = HighValue;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[AndSqlWhereWithISNULL](@TableAlias, @ColumnName, @NullValue, @UseQuotes, @LowValue, @HighValue)";

                appDB.AddCommandParameter(cmd, "TableAlias", _TableAlias, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NullValue", _NullValue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UseQuotes", _UseQuotes, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LowValue", _LowValue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HighValue", _HighValue, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
