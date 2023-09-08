//PROJECT NAME: MG.MGCore
//CLASS NAME: NextKey.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class NextKey : INextKey
    {
        IApplicationDB appDB;


        public NextKey(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string KeyStr,
        string Infobar) NextKeySp(string TableName,
        string ColumnName,
        string Prefix,
        int? KeyLength,
        string Type,
        string Where = null,
        string TableName2 = null,
        string Where2 = null,
        string KeyStr = null,
        string Infobar = null)
        {
            StringType _TableName = TableName;
            StringType _ColumnName = ColumnName;
            LongListType _Prefix = Prefix;
            IntType _KeyLength = KeyLength;
            LongListType _Type = Type;
            LongListType _Where = Where;
            StringType _TableName2 = TableName2;
            LongListType _Where2 = Where2;
            LongListType _KeyStr = KeyStr;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "NextKeySp";

                appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Where", _Where, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TableName2", _TableName2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Where2", _Where2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "KeyStr", _KeyStr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                KeyStr = _KeyStr;
                Infobar = _Infobar;

                return (Severity, KeyStr, Infobar);
            }
        }
    }
}
