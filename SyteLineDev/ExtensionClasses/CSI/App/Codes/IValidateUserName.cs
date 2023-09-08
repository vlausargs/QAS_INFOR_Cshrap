//PROJECT NAME: Codes
//CLASS NAME: IValidateUserName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
    public interface IValidateUserName
    {
        (int? ReturnCode, string Infobar) ValidateUserNameSp(string UserName, string Infobar);
    }
}

