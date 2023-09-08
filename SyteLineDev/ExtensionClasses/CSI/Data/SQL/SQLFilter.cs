//PROJECT NAME: Data
//CLASS NAME: SqlFilter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class SqlFilter : ISqlFilter
    {
        readonly IApplicationDB appDB;


        public SqlFilter(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string SqlFilterFn(
            string Filter,
            string PropertyList,
            string ColumnList,
            string Delim)
        {
            LongListType _Filter = Filter;
            LongListType _PropertyList = PropertyList;
            LongListType _ColumnList = ColumnList;
            StringType _Delim = Delim;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[SqlFilter](@Filter, @PropertyList, @ColumnList, @Delim)";

                appDB.AddCommandParameter(cmd, "Filter", _Filter, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PropertyList", _PropertyList, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ColumnList", _ColumnList, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Delim", _Delim, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
