//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetUserCRUD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
    public interface IRSQC_GetUserCRUD
    {
        bool Optional_ModuleForExists();
        ICollectionLoadResponse Optional_Module1Select();
        void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse);
        bool Tv_ALTGENForExists();
        string Tv_ALTGEN1Load();
        ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName);
        void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse);
        string User_LocalLoad();
        (int? ReturnCode, string o_user, string Infobar) AltExtGen_RSQC_GetUserSp(string AltExtGenSp, string o_user, string Infobar);
    }
}