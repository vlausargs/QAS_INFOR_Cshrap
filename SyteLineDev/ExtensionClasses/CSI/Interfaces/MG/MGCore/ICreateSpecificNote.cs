//PROJECT NAME: MG.MGCore
//CLASS NAME: ICreateSpecificNote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ICreateSpecificNote
    {
        (int? ReturnCode, string Infobar) CreateSpecificNoteSp(string ObjectName,
        Guid? RowPointer,
        string NoteDesc,
        string NoteText,
        int? InternalFlag,
        string Infobar);
    }
}

