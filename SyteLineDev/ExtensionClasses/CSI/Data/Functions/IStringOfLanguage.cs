//PROJECT NAME: Data
//CLASS NAME: IStringOfLanguage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IStringOfLanguage
    {
        string StringOfLanguageFn(
            string Parm,
            string MessageLanguage);
    }
}
