//PROJECT NAME: MG.MGCore
//CLASS NAME: CopyUetColumns.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class CopyUetColumns : ICopyUetColumns
    {
        IApplicationDB appDB;


        public CopyUetColumns(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) CopyUetColumnsSp(string TableName,
        Guid? FromRowPointer,
        Guid? ToRowPointer,
        string Infobar)
        {
            TableNameType _TableName = TableName;
            RowPointerType _FromRowPointer = FromRowPointer;
            RowPointerType _ToRowPointer = ToRowPointer;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CopyUetColumnsSp";

                appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromRowPointer", _FromRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
