using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface IFSObjectNotes
    {
        int CU_NotesSp(string TableName,
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
