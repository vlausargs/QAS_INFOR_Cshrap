//PROJECT NAME: MG.MGCore
//CLASS NAME: IGetErrorMessage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IGetErrorMessage
    {
        (int? ReturnCode, string Infobar) GetErrorMessageSp(string ObjectName,
        int? MessageType,
        string Infobar);
    }
}

