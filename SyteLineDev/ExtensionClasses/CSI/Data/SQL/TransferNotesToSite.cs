//PROJECT NAME: MG.MGCore
//CLASS NAME: TransferNotesToSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class TransferNotesToSite : ITransferNotesToSite
    {
        IApplicationDB appDB;


        public TransferNotesToSite(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) TransferNotesToSiteSp(string ToSite,
        string TableName,
        Guid? RowPointer,
        string ToWhereClause,
        Guid? ToRowPointer,
        int? DeleteFirst,
        string Infobar)
        {
            SiteType _ToSite = ToSite;
            StringType _TableName = TableName;
            RowPointerType _RowPointer = RowPointer;
            LongListType _ToWhereClause = ToWhereClause;
            RowPointerType _ToRowPointer = ToRowPointer;
            FlagNyType _DeleteFirst = DeleteFirst;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TransferNotesToSiteSp";

                appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToWhereClause", _ToWhereClause, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToRowPointer", _ToRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DeleteFirst", _DeleteFirst, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
