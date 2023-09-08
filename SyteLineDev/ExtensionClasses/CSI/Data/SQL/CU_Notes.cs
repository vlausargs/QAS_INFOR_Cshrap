//PROJECT NAME: MG.MGCore
//CLASS NAME: CU_Notes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.ExternalContracts.Portals;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public class CU_Notes : ICU_Notes, IFSObjectNotes
    {
        IApplicationDB appDB;

        public CU_Notes(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, decimal? ObjectNoteToken,
        decimal? SystemNoteToken,
        decimal? UserNoteToken,
        decimal? SpecificNoteToken) CU_NotesSp(string TableName,
        string RefRowPointer,
        string TypeNote,
        int? NoteFlag,
        string NoteDesc,
        string NoteContent,
        decimal? ObjectNoteToken,
        decimal? SystemNoteToken,
        decimal? UserNoteToken,
        decimal? SpecificNoteToken)
        {
            LongListType _TableName = TableName;
            LongRowPointerType _RefRowPointer = RefRowPointer;
            LongDescType _TypeNote = TypeNote;
            FlagIeType _NoteFlag = NoteFlag;
            LongDescType _NoteDesc = NoteDesc;
            OleObjectType _NoteContent = NoteContent;
            TokenType _ObjectNoteToken = ObjectNoteToken;
            TokenType _SystemNoteToken = SystemNoteToken;
            TokenType _UserNoteToken = UserNoteToken;
            TokenType _SpecificNoteToken = SpecificNoteToken;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CU_NotesSp";

                appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRowPointer", _RefRowPointer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TypeNote", _TypeNote, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NoteFlag", _NoteFlag, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NoteDesc", _NoteDesc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NoteContent", _NoteContent, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ObjectNoteToken", _ObjectNoteToken, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SystemNoteToken", _SystemNoteToken, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UserNoteToken", _UserNoteToken, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SpecificNoteToken", _SpecificNoteToken, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                ObjectNoteToken = _ObjectNoteToken;
                SystemNoteToken = _SystemNoteToken;
                UserNoteToken = _UserNoteToken;
                SpecificNoteToken = _SpecificNoteToken;

                return (Severity, ObjectNoteToken, SystemNoteToken, UserNoteToken, SpecificNoteToken);
            }
        }

        int IFSObjectNotes.CU_NotesSp(string TableName, string RefRowPointer, string TypeNote, int? NoteFlag, string NoteDesc, string NoteContent, decimal? ObjectNoteToken, decimal? SystemNoteToken, decimal? UserNoteToken, decimal? SpecificNoteToken)
        {
            throw new NotImplementedException();
        }
    }
}
