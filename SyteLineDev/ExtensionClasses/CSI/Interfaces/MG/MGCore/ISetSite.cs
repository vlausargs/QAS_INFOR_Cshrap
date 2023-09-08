//PROJECT NAME: MG.MGCore
//CLASS NAME: ISetSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ISetSite
    {
        (int? ReturnCode, string Infobar) SetSite(string Site, string Infobar);
        //void SetSiteSp2(string site, string infobar);
    }
}

