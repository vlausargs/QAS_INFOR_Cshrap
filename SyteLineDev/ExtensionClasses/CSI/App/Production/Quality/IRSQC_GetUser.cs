//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetUser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
    public interface IRSQC_GetUser
    {
        (int? ReturnCode,
        string o_user,
        string Infobar) RSQC_GetUserSp(
            string o_user,
            string Infobar);
    }
}