//PROJECT NAME: MG.MGCore
//CLASS NAME: SetNextKey.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class SetNextKey : ISetNextKey
    {
        IApplicationDB appDB;


        public SetNextKey(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string KeyStr,
        string Infobar) SetNextKeySp(string TableName,
        string ColumnName,
        string Prefix,
        int? KeyLength,
        string Type,
        string SubKey = null,
        string TableName2 = null,
        string SubKey2 = null,
        string KeyStr = null,
        string Infobar = null,
        int? Increment = 1)
        {
            StringType _TableName = TableName;
            StringType _ColumnName = ColumnName;
            LongList _Prefix = Prefix;
            IntType _KeyLength = KeyLength;
            LongList _Type = Type;
            GenericKeyType _SubKey = SubKey;
            StringType _TableName2 = TableName2;
            GenericKeyType _SubKey2 = SubKey2;
            LongList _KeyStr = KeyStr;
            Infobar _Infobar = Infobar;
            IntType _Increment = Increment;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SetNextKeySp";

                appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Prefix", _Prefix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SubKey", _SubKey, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TableName2", _TableName2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SubKey2", _SubKey2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "KeyStr", _KeyStr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Increment", _Increment, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                KeyStr = _KeyStr;
                Infobar = _Infobar;

                return (Severity, KeyStr, Infobar);
            }
        }
    }
}
