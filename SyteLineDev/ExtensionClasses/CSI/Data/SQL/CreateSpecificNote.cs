//PROJECT NAME: MG.MGCore
//CLASS NAME: CreateSpecificNote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class CreateSpecificNote : ICreateSpecificNote
    {
        IApplicationDB appDB;


        public CreateSpecificNote(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) CreateSpecificNoteSp(string ObjectName,
        Guid? RowPointer,
        string NoteDesc,
        string NoteText,
        int? InternalFlag,
        string Infobar)
        {
            StringType _ObjectName = ObjectName;
            RowPointerType _RowPointer = RowPointer;
            LongDescType _NoteDesc = NoteDesc;
            LongListType _NoteText = NoteText;
            FlagIeType _InternalFlag = InternalFlag;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreateSpecificNoteSp";

                appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NoteDesc", _NoteDesc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NoteText", _NoteText, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InternalFlag", _InternalFlag, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
