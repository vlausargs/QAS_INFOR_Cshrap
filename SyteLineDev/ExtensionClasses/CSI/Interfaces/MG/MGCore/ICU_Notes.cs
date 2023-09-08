//PROJECT NAME: MG.MGCore
//CLASS NAME: ICU_Notes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ICU_Notes
    {
        (int? ReturnCode, decimal? ObjectNoteToken,
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
        decimal? SpecificNoteToken);
    }
}

