//PROJECT NAME: MG.MGCore
//CLASS NAME: IInterpretText.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IInterpretText
    {
        (int? ReturnCode, string InterpretedText,
        string Infobar) InterpretTextSp(string Text,
        string UserName = null,
        string InterpretedText = null,
        string Infobar = null);
    }
}

